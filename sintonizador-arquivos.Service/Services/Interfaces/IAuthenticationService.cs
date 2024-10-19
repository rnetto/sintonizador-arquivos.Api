using sintonizador_arquivos.Aplication.DTO;

namespace sintonizador_arquivos.Aplication.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponseDTO> LoginAuth(LoginDTO loginDTO, CancellationToken cancellationToken);
    }
}
