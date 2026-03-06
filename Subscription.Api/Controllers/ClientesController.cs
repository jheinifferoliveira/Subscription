using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IActionResult> CriarAsync()
        {
            return StatusCode(501, new { message = "Não implementado." });
        }

        [HttpGet("listar")]
        public  async Task<IActionResult> ConsultarAsync(int page = 1, int pageSize = 10)
        {
            return StatusCode(501, new { message = "Não implementado." });
        }

        [HttpGet("obter/{id}")]
        public async Task<IActionResult> ObterAsync()
        {
            return StatusCode(501, new { message = "Não implementado." });
        }
    }
}
