using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Service.Auth
{
    public class AuthService : IAuthService
    {
        public readonly UserManager<IdentityUser> _userManager;
        public readonly IMapper _mapper;
        public readonly ITokenService _tokenService;
        public AuthService(UserManager<IdentityUser> userManager, IMapper mapper,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<UserResponse> RegisterAsync(UserRegisterRequest request)
        {
        
            var newUser = _mapper.Map<IdentityUser>(request);

         
            var result = await _userManager.CreateAsync(newUser, request.Password); // registered
            var role = await _userManager.AddToRoleAsync(newUser, request.Role);
            // generate token
            var token = await _tokenService.GenerateToken(newUser);  // token function



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
        
            // Update user information in database
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to update user: {result.Errors}");
            }

            var userResponse = _mapper.Map<UserResponse>(user);
            userResponse.Token = token;

            return userResponse;
        }

    }
}
