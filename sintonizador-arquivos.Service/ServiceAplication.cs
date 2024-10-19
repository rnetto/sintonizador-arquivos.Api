using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using sintonizador_arquivos.Aplication.Services;
using sintonizador_arquivos.Aplication.Services.Interfaces;

namespace sintonizador_arquivos.Aplication;

public static class ServiceAplication
{
    public static IServiceCollection RegisterAplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigureAplication(services, configuration);
        return services;
    }
    private static void ConfigureAplication(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
    }
}
