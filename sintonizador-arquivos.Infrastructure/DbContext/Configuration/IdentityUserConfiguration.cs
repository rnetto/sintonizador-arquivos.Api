using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace sintonizador_arquivos.Infrastructure.DbContext.Configuration;

public class IdentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        // Ignorar colunas que não existem no banco de dados
        builder.Ignore(e => e.AccessFailedCount);
        builder.Ignore(e => e.ConcurrencyStamp);
        builder.Ignore(e => e.Email);
        builder.Ignore(e => e.EmailConfirmed);
        builder.Ignore(e => e.LockoutEnabled);
        builder.Ignore(e => e.LockoutEnd);
        builder.Ignore(e => e.NormalizedEmail);
        builder.Ignore(e => e.PhoneNumber);
        builder.Ignore(e => e.PhoneNumberConfirmed);
        builder.Ignore(e => e.TwoFactorEnabled);
        builder.Ignore(e => e.UserName);

        // Configuração para renomear a coluna UserName
        builder.Property(u => u.NormalizedUserName).HasColumnName("UserName");
    }
}
