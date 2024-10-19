using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sintonizador_arquivos.Infrastructure.DbContext.Configuration;

namespace sintonizador_arquivos.Infrastructure.DbContext
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) 
                    : IdentityDbContext<IdentityUser>(options)
    {
        //DbSet<IdentityUser> IdentityUsers;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new IdentityUserConfiguration());
        }
    }
}
