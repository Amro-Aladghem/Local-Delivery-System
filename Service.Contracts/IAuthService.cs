using Shared.DataTransferObjects.User;

namespace Service.Contracts
{
    public interface IAuthService
    {
        Task<UserForAuthenticationResponse?> AuthenticateUser(UserForAuthenticationRequest request);
        Task<UserForAuthenticationResponse?> RegisterUser(UserForRegisterationRequest request);
        Task<UserPreRegisterResponse?> PreRegisterUser(UserPreRegisterRequest request);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        Task<TokenDto> CreateToken(bool populateExp);
    }
}
