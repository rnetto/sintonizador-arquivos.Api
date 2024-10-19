using Microsoft.AspNetCore.Mvc;
using sintonizador_arquivos.Aplication.DTO;
using sintonizador_arquivos.Aplication.Services.Interfaces;

namespace sintonizador_arquivos_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(IAuthenticationService authenticationService) : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = authenticationService;
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model, CancellationToken cancellationToken)
        {
            var login = await _authenticationService.LoginAuth(model, cancellationToken);
            return Ok(login);
        }
    }
}
