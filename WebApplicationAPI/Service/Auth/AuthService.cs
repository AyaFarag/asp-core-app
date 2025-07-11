using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApplicationAPI.DTO;
using System.Security.Cryptography;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Service.Auth
{
    public class AuthService : IAuthService
    {
        public readonly UserManager<UserModel> _userManager;
        public readonly RoleManager<IdentityRole> _roleManager;
        public readonly IMapper _mapper;
        public readonly ITokenService _tokenService;
        public AuthService(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager .IMapper mapper,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
            _roleManager = roleManager;
        }
        public async Task<UserResponse> RegisterAsync(UserRegisterRequest request)
        {
        
            var newUser = _mapper.Map<UserModel>(request);


            var result = await _userManager.CreateAsync(newUser, request.Password); // registered
            var role = await _userManager.AddToRoleAsync(newUser, request.Role);
            // generate token
            var token = await _tokenService.GenerateToken(newUser);  // token function

            // refresh token

            var response = _mapper.Map<UserResponse>(newUser);
            response.Token = token;
            response.Role = request.Role;

            return response;
        }

        public async Task<UserResponse> LoginAsync(UserLoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new Exception("Invalid email or password");
            }

            // Generate access token
            var token = await _tokenService.GenerateToken(user); // gernerate token
        
           

               // Generate refresh token
           var refreshToken = _tokenService.GenerateRefreshToken();

            // Hash the refresh token and store it in the database or override the existing refresh token
            using var sha256 = SHA256.Create();
            var refreshTokenHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(refreshToken));
         //   user.RefreshToken = Convert.ToBase64String(refreshTokenHash);
         //   user.RefreshTokenExpiryTime = DateTime.Now.AddMinutes(10);

            // Update user information in database
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to update user: {errors}");
            }

            var userResponse = _mapper.Map<UserResponse>(user);
            userResponse.Token = token;
            userResponse.RefreshToken = refreshToken;


            return userResponse;
        }

    }
}
