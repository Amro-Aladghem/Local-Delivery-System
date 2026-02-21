using Shared.DataTransferObjects.User;


namespace Service.Contracts
{
    public interface IAuthService
    {
        Task<AuthUserResponseResult?> AuthenticateUser(UserForAuthenticationRequest request);
        Task<AuthUserResponseResult?> RegisterUser(UserForRegisterationRequest request);
        Task<PreRegisterResponseResult?> PreRegisterUser(UserPreRegisterRequest request);
        Task<TokenDto?> RefreshToken(string AccessToken, string RefreshToken);
    }
}
