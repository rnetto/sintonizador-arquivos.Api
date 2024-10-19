namespace sintonizador_arquivos.Infrastructure.Configurations;

public class JwtSettings
{
    public const string SessionName = "JWT";
    public string Key { get; init; }
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int ExpireHours { get; init; } = 1;
}
