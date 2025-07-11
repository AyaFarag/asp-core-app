using Microsoft.AspNetCore.Identity;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Service.Auth
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserModel user);
        string GenerateRefreshToken();
    }
}
