using AutoMapper;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Contracts;
using Shared.DataTransferObjects.User;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.UserService
{
    public class AuthService : IAuthService
    {
        enum eAuthWith { Email, Phone }

        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IOptions<JwtConfiguration> _configuration;

        private readonly JwtConfiguration _jwtConfiguration;

        private User? _user;
        public AuthService(UserManager<User> userManager, IMapper mapper, ILogger logger,IOptions<JwtConfiguration> jwtConfiguration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _jwtConfiguration = jwtConfiguration.Value;
        }
        public async Task<UserForAuthenticationResponse?> AuthenticateUser(UserForAuthenticationRequest request)
        {
            eAuthWith eAuthWith = string.IsNullOrEmpty(request.Email) ? eAuthWith.Phone : eAuthWith.Email;

            User ? user =  eAuthWith switch
            {
                eAuthWith.Email => await _userManager.FindByEmailAsync(request.Email),
                eAuthWith.Phone => await _userManager.Users.FirstOrDefaultAsync(U=>U.PhoneNumber==request.PhoneNumber),
                _=>null
            };

            if (user is null)
                return null;

            var userRoles = await  _userManager.GetRolesAsync(user);

            UserForAuthenticationResponse response = _mapper.Map<User,UserForAuthenticationResponse>(user);
            response.SystemRole = userRoles[0];

            return response;
        }

        public async Task<UserPreRegisterResponse?> PreRegisterUser(UserPreRegisterRequest request)
        {
            User user = _mapper.Map<UserPreRegisterRequest,User>(request);
            user.IsActive = false;

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return null;

            var roleResult = await _userManager.AddToRoleAsync(user,request.SystemRole);

            if (!roleResult.Succeeded)
                return null;

            UserPreRegisterResponse response = _mapper.Map<UserPreRegisterRequest, UserPreRegisterResponse>(request);
            response.UserId = user.Id;

            return response;
        }

        public async Task<UserForAuthenticationResponse?> RegisterUser(UserForRegisterationRequest request)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(U => U.Id == request.UserId &&U.IsActive ==false);
            if (user is null)
                return null;

            _mapper.Map(request, user);
            user.IsActive = true;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return null;

            var userRoles = await _userManager.GetRolesAsync(user);

            UserForAuthenticationResponse response = _mapper.Map<User, UserForAuthenticationResponse>(user);
            response.SystemRole = userRoles[0];

            return response;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Secrete);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            string userName = $"{_user?.FirstName} {_user?.LastName}".Trim();
            string countryId = _user?.CountryId?.ToString() ?? "0";

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = _user?.UserName ?? "PreRegisterUser";
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Country, countryId),
                new Claim(ClaimTypes.NameIdentifier,_user.Id.ToString()),
            };

            var roles = await _userManager.GetRolesAsync(_user!);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }


        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber); 
                return Convert.ToBase64String(randomNumber);
            }
        }


        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfiguration.Secrete)),
                ValidateLifetime = true,
                ValidIssuer = _jwtConfiguration.ValidIssuer,
                ValidAudience = _jwtConfiguration.ValidAudience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user.ReffreshToken = refreshToken;

            if (populateExp)
                _user.ReffreshTokenExpired = DateTime.Now.AddDays(7);

            await _userManager.UpdateAsync(_user);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(accessToken, refreshToken);
        }

        public async Task<TokenDto> RefreshToken(TokenDto tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new SecurityTokenException("Invalid token: User ID claim is missing");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null || user.ReffreshToken != tokenDto.RefreshToken ||
            user.ReffreshTokenExpired <= DateTime.Now)
                throw new ReffreshTokenBadRequest("Invailed Token");

            _user = user;
            return await CreateToken(populateExp: false);
        }

    }
}
