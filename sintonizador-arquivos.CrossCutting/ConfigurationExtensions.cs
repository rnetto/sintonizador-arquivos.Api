using Microsoft.Extensions.Configuration;

namespace sintonizador_arquivos.CrossCutting
{
    public static class ConfigurationExtensions
    {
        public static T GetSection<T>(this IConfiguration configuration, string sectionName)
            where T : class, new()
        {
            var section = configuration.GetSection(sectionName);
            var settings = section.Get<T>();
            return settings ?? throw new InvalidOperationException($"Configuration section '{sectionName}' not found or empty.");
        }
    }
}
