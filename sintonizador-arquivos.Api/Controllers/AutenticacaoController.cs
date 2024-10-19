//using Microsoft.AspNetCore.Mvc;
//using sintonizador_arquivos.Aplication.DTO;

//namespace sintonizador_arquivos_api.Controllers
//{
//    [Route("api/")]
//    [ApiController]
//    public class AutenticacaoController : ControllerBase
//    {
//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginDTO model)
//        {
//            if (model.UserName.Equals("falhar"))
//            {
//                return Unauthorized("Usuário ou senha inválido(s).");
//            }

//            var obj = new RetornoLogin { Valido = true, Vencimento = DateTime.Now, Claim = "medicoLaudador", IdLaudador = $"guid-id-{model.UserName}" };

//            return Ok(obj);
//        }

//        [HttpPost("sincronizarExames")]
//        public async Task<IActionResult> SincronizarExames([FromBody] string idLaudador)
//        {
//            var obj = new SincronizarEstudos();

//            if (idLaudador.Contains("01"))
//            {
//                for (int i = 0; i < 13; i++)
//                {
//                    obj.EstudosDelete.Add(
//                        $"estudo - 0{i}.exe"
//                    );
//                    i++;
//                }
//                //}
//                //else if (idLaudador.Contains("02"))
//                //{
//                for (int i = 0; i < 13; i++)
//                {
//                    obj.EstudosDownloads.Add(new EstudosDownload
//                    {
//                        Id = Guid.NewGuid().ToString(),
//                        NomeArquivo = $"estudo - 0{i}"
//                    });
//                }
//            }

//            return Ok(obj);
//        }

//        [HttpGet("downloadExame")]
//        public async Task<IActionResult> DownloadExame(string idExame)
//        {
//            var urlAssinada = $@"https://dl.pstmn.io/download/latest/win64";

//            return Ok(urlAssinada);
//        }

//    }

//    public class RetornoLogin
//    {
//        public bool Valido { get; set; }
//        public DateTime Vencimento { get; set; }
//        public string? Claim { get; set; }
//        public string? IdLaudador { get; set; }
//    }

//    public class EstudosDownload
//    {
//        public string Id { get; set; }
//        public string NomeArquivo { get; set; }
//    }

//    public class SincronizarEstudos
//    {
//        public List<EstudosDownload> EstudosDownloads { get; set; } = new List<EstudosDownload>();
//        public List<string> EstudosDelete { get; set; } = new List<string>();
//    }
//}
