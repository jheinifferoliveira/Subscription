using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController : ControllerBase
    {

        [HttpGet("listar")]
        public async Task<IActionResult> ConsultarAsync(int page = 1, int pageSize = 10)
        {
            return StatusCode(501, new { message = "Não implementado." });
        }
    }
}
