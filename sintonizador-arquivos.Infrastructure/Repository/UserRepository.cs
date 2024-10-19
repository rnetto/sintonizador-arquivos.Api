using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sintonizador_arquivos.Infrastructure.DbContext;
using sintonizador_arquivos.Infrastructure.Repository.Interface;

namespace sintonizador_arquivos.Infrastructure.Repository;

internal class UserRepository(AppDbContext appDbContext) : IUserRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<IdentityUser> GetUserByName(string userName)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.NormalizedUserName == userName);
        return result;
    }

    public async Task<string[]> GetRolesByUser(string userId)
    {
        var result = await _context.UserRoles
                                   .Where(ur => ur.UserId == userId)
                                   .Join(_context.Roles,
                                         ur => ur.RoleId,
                                         r => r.Id,
                                         (ur, r) => r.Name)
                                   .ToArrayAsync();
        return result!;
    }   
}
