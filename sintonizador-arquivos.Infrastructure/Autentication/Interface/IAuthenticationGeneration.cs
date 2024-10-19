using Microsoft.AspNetCore.Identity;

namespace sintonizador_arquivos.Infrastructure.Autentication.Interface;

public interface IAuthenticationGeneration
{
    string GenerateJwtToken(IdentityUser user, IList<string> roles);
    bool VerifyPassword(IdentityUser user, string password);
}
