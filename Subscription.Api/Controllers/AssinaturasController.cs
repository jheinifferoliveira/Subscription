using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturasController : ControllerBase
    {
        [HttpPost("criar")]
        public async Task<IActionResult> CriarAsync()
        {
            return StatusCode(501, new { message = "Não implementado." });
        }

        [HttpPost("cancelar")]
        public async Task<IActionResult> CancelarAsync()
        {
            return StatusCode(501, new { message = "Não implementado." });
        }


        [HttpPost("suspender")]
        public async Task<IActionResult> SuspenderAsync()
        {
            return StatusCode(501, new { message = "Não implementado." });
        }
    }
}
