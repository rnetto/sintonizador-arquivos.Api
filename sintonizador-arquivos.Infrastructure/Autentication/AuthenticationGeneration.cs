using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using sintonizador_arquivos.Infrastructure.Autentication.Interface;
using sintonizador_arquivos.Infrastructure.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace sintonizador_arquivos.Infrastructure.Autentication;

internal class AuthenticationGeneration(JwtSettings JwtSettings) : IAuthenticationGeneration
{
    private readonly JwtSettings _JwtSettings = JwtSettings;

    public string GenerateJwtToken(IdentityUser user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim("role", role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSettings.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _JwtSettings.Issuer,
            audience: _JwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddHours(_JwtSettings.ExpireHours),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public bool VerifyPassword(IdentityUser user, string password)
    {
        var passwordHasher = new PasswordHasher<IdentityUser>();
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash!, password);

        return result == PasswordVerificationResult.SuccessRehashNeeded;
    }
}
