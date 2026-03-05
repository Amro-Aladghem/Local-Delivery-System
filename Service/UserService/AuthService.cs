using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Exceptions;
using Entities.Models;
using Enums;
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
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IOptions<JwtConfiguration> _configuration;

        private JwtConfiguration _jwtConfiguration;

        //private User? _user;
        public AuthService(UserManager<User> userManager, IMapper mapper, ILogger logger,IOptions<JwtConfiguration> jwtConfiguration,IManagerRepository managerRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _logger = logger;
            _configuration = jwtConfiguration;
            _managerRepository = managerRepository;

            _jwtConfiguration = _configuration.Value;
        }

        public async Task<AuthUserResponseResult?> AuthenticateUser(UserForAuthenticationRequest request)
        {
            eAuthWith eAuthWith = string.IsNullOrEmpty(request.Email) ? eAuthWith.Phone : eAuthWith.Email;
            Guid? profileId = null;

            User ? user =  eAuthWith switch
            {
                eAuthWith.Email => await _userManager.FindByEmailAsync(request.Email),
                eAuthWith.Phone => await _userManager.Users.FirstOrDefaultAsync(U=>U.PhoneNumber==request.PhoneNumber),
                _=>null
            };

            if (user is null || !user.IsActive)
                return null;

            var userRoles = await  _userManager.GetRolesAsync(user);

            UserForAuthenticationResponse AuthUser = _mapper.Map<User,UserForAuthenticationResponse>(user);
            AuthUser.SystemRole = userRoles[0];

            profileId = await GetUserProfileId(userRoles[0], user.Id);

            TokenDto? tokenDto = await CreateToken(true, user, profileId);

            if(tokenDto is null) return null;

            return new AuthUserResponseResult() { Token = tokenDto,User= AuthUser };
        }

        private async Task<Guid?> GetUserProfileId(string RoleName,Guid IdentityUserId)
        {
            Task<Guid?>? task = RoleName switch
            {
                "Driver"=>_managerRepository.Driver.GetDriverIdByUserIdentityId(IdentityUserId,false),
                "DeliveryCompanyUser"=>_managerRepository.DeliveryCompanyUser.GetDeliveryCompanyUserIdByIdentityId(IdentityUserId,false),
                "DeliveryClient" => _managerRepository.DeliveryClientUser.GetDeliveryClientUserIdByIdentityId(IdentityUserId,false),
                _=> null
            };

            if (task is null) return null;

            Guid? ProfileId = await task;
            return ProfileId;
        }

        public async Task<PreRegisterResponseResult?> PreRegisterUser(UserPreRegisterRequest request)
        {
            User user = _mapper.Map<UserPreRegisterRequest,User>(request);
            user.IsActive = false;

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return null;

            var roleResult = await _userManager.AddToRoleAsync(user,SystemUserRoles.PreRegister.ToString());

            if (!roleResult.Succeeded)
                return null;

            UserPreRegisterResponse AuthUser = _mapper.Map<UserPreRegisterRequest, UserPreRegisterResponse>(request);
            AuthUser.UserId = user.Id;

            TokenDto? token = await CreateToken(true, user);

            if (token is null) return null;

            return new PreRegisterResponseResult() { Token = token, User = AuthUser };
        }

        public async Task<UserForAuthenticationResponse?> RegisterUser(UserForRegisterationRequest request,Guid PreRegisterUserId,string systemUserRole)
        {
            User? user = await _userManager.Users.FirstOrDefaultAsync(U => U.Id == PreRegisterUserId && U.IsActive ==false);

            if (user is null)
                return null;

            _mapper.Map(request, user);
            user.IsActive = true;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return null;

            var roleResult = await _userManager.AddToRoleAsync(user,systemUserRole);

            if (!roleResult.Succeeded)
                return null;


            UserForAuthenticationResponse AuthUser = _mapper.Map<User, UserForAuthenticationResponse>(user);
            AuthUser.SystemRole = systemUserRole;

            return AuthUser;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtConfiguration.Secrete);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(User user, Guid? ProfileId = null)
        {
            string userName = $"{user?.FirstName} {user?.LastName}".Trim();
            string countryId = user?.CountryId?.ToString() ?? "0";

            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = user?.UserName ?? "PreRegisterUser";
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Country, countryId),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            };

            if (ProfileId is not null)
            {
                claims.Add(new Claim("profile_id", ProfileId.ToString()));
            }

            var roles = await _userManager.GetRolesAsync(user!);
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
                ValidateLifetime = false,
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

        private async Task<TokenDto?> CreateToken(bool populateExp,User user,Guid? ProfileId=null)
        {
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims(user,ProfileId);
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            user.ReffreshToken = refreshToken;

            if (populateExp)
                user.ReffreshTokenExpired = DateTime.Now.AddDays(7);

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return null;

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(accessToken, refreshToken);
        }

        public async Task<TokenDto?> RefreshToken(string AccessToken,string RefreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(AccessToken);

            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                throw new SecurityTokenException("Invalid token: User ID claim is missing");
            }

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null || user.ReffreshToken != RefreshToken ||
            user.ReffreshTokenExpired <= DateTime.Now)
                throw new ReffreshTokenBadRequest("Invailed Token");

            return await CreateToken(populateExp: false,user);
        }

        public async Task<TokenDto?> GenerateTokenForUser(Guid userId, Guid? profileId = null)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null) return null;

            return await CreateToken(populateExp: true, user, profileId);
        }

        public async Task<bool> LogoutUser(Guid userId)
        {
            User? user = await _userManager.FindByIdAsync(userId.ToString());

            if (user is null)
                return false;

            user.ReffreshTokenExpired = null;
            user.ReffreshToken = null;

            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
                return false;

            return true;
        }
    }
}
