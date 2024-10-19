using sintonizador_arquivos.Aplication.DTO;
using sintonizador_arquivos.Aplication.Services.Interfaces;
using sintonizador_arquivos.Infrastructure.Autentication.Interface;
using sintonizador_arquivos.Infrastructure.Repository.Interface;
namespace sintonizador_arquivos.Aplication.Services;

public class AuthenticationService(IAuthenticationGeneration authenticationGeneration, IUserRepository userRepository)
                                  : IAuthenticationService
{
    private readonly IAuthenticationGeneration _authGeneration = authenticationGeneration;
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<LoginResponseDTO> LoginAuth(LoginDTO loginDTO, CancellationToken cancellationToken)
    {
        var userLogin = await _userRepository.GetUserByName(loginDTO.UserName);
        if (userLogin == null || !_authGeneration.VerifyPassword(userLogin, loginDTO.Password))
            return new LoginResponseDTO { Message = "Erro no login. Usuário/senha inválidos." };

        var roles = await _userRepository.GetRolesByUser(loginDTO.UserName);
        var token = _authGeneration.GenerateJwtToken(userLogin, roles);

        var loginResponse = new LoginResponseDTO()
        {
            Token = token,
            User = new UserDTO { Id = userLogin.Id, UserName = userLogin.NormalizedUserName! },
            Expiration = DateTime.UtcNow.AddHours(10),
            Message = "Sucesso"
        };

        return loginResponse;
    }
}
