
using GrantAdvance.Backend.Application.Abstractions.Authentication;
using GrantAdvance.Backend.Infrastructure.Authentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GrantAdvance.Backend.Infrastructure.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;

    public AuthenticationService(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
    }

    public async Task<string> LoginAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            throw new ArgumentException("Invalid username or password.");

        //var userRoles = await _userManager.GetRolesAsync(user);

        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        //foreach (var userRole in userRoles)
        //{
        //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        //}

        string token = GenerateToken(authClaims);

        return token;
    }

    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
        var tokenExpirationInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpirationInHour"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = _configuration["JWTKey:ValidIssuer"],
            Audience = _configuration["JWTKey:ValidAudience"],
            Expires = DateTime.UtcNow.AddHours(tokenExpirationInHour),
            SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}