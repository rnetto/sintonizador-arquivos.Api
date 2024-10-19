namespace sintonizador_arquivos.Aplication.DTO;
public class LoginResponseDTO
{
    public string Token { get; set; }
    public UserDTO User { get; set; }
    public DateTime Expiration { get; set; }
    public string Message { get; set; }
}
