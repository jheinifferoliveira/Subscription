using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using Subscription.Domain.Interfaces.Services;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssinaturasController(IAssinaturaService assinaturaService) : ControllerBase
    {

        [ProducesResponseType(typeof(AssinaturaResponse), 201)]
        [HttpPost("criar")]
        public async Task<IActionResult> CriarAsync([FromBody] AssinaturaRequest request)
        {
           var response = await assinaturaService.CriarAsync(request);

            return StatusCode(201, response);
        }

    }
}
