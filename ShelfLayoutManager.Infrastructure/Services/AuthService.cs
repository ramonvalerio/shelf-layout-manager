using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShelfLayoutManager.Core.Services;
using ShelfLayoutManager.Infrastructure.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShelfLayoutManager.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<bool> RegisterUser(string userName, string password)
        {
            var identityUser = new ApplicationUser
            {
                UserName = userName,
                Email = userName
            };

            var result = await _userManager.CreateAsync(identityUser, password);
            return result.Succeeded;
        }

        public async Task<bool> Login(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user is null)
                return false;

            return await _userManager.CheckPasswordAsync(user, password);
        }

        public async Task<string> GenerateTokenString(string userName)
        {
            var user = await _userManager.FindByEmailAsync(userName);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
            claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                signingCredentials: signingCredentials
            );

            var token = new JwtSecurityTokenHandler();

            return token.WriteToken(securityToken);
        }
    }
}