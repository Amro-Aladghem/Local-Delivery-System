using Shared.DataTransferObjects.User;


namespace Service.Contracts
{
    public interface IAuthService
    {
        Task<AuthUserResponseResult?> AuthenticateUser(UserForAuthenticationRequest request);
        Task<UserForAuthenticationResponse?> RegisterUser(UserForRegisterationRequest request, Guid PreRegisterUserId,string systemRole);
        Task<PreRegisterResponseResult?> PreRegisterUser(UserPreRegisterRequest request);
        Task<TokenDto?> RefreshToken(string AccessToken, string RefreshToken);
        Task<TokenDto?> GenerateTokenForUser(Guid userId, Guid? profileId = null);
        Task<bool> LogoutUser(Guid userId);
        Task<UserForAuthenticationResponse?> CreateUserByManagerRole(UserForRegisterationRequest request, string systemUserRole,string Password);
    }
}
