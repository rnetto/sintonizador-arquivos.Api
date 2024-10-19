using Microsoft.AspNetCore.Identity;
namespace sintonizador_arquivos.Infrastructure.Repository.Interface;

public interface IUserRepository
{
    Task<IdentityUser> GetUserByName(string userName);
    Task<string[]> GetRolesByUser(string userId);
}
