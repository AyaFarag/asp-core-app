using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Service.Auth
{
    public interface IAuthService
    {
        public Task<UserResponse> RegisterAsync(UserRegisterRequest request);
        public Task<UserResponse> LoginAsync(UserLoginRequest request);


    }
}
