using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sintonizador_arquivos.Infrastructure.Autentication;
using sintonizador_arquivos.Infrastructure.Autentication.Interface;
using sintonizador_arquivos.Infrastructure.Configurations;
using sintonizador_arquivos.Infrastructure.DbContext;
using sintonizador_arquivos.Infrastructure.Repository;
using sintonizador_arquivos.Infrastructure.Repository.Interface;
using sintonizador_arquivos.CrossCutting;

namespace sintonizador_arquivos.Infrastructure;

public static class RegisterInfraStructureServicesConfiguration
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureInfrastructure(services, configuration);
        return services;
    }
    private static void ConfigureInfrastructure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextConfiguration(configuration);
        ConfigureIoptions(services, configuration);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAuthenticationGeneration, AuthenticationGeneration>();
    }

    private static void AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
                    options.UseMySql(configuration.GetConnectionString("syncFilesConnection"),
                        new MySqlServerVersion(new Version(8, 0, 39)))
                    .EnableSensitiveDataLogging());

        // Configura o Identity com os serviços padrões
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(options =>
        {
            // Configurações de senha, bloqueio, etc.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        });

        services.AddAuthentication();
        services.AddAuthorization();
    }

    private static void ConfigureIoptions(IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection<JwtSettings>(JwtSettings.SessionName);
        services.AddSingleton(jwtSettings);
    }
}
