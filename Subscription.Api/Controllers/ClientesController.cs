using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscription.Domain.Dtos.Requests;
using Subscription.Domain.Dtos.Responses;
using Subscription.Domain.Entities;
using Subscription.Domain.Interfaces.Services;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IClienteService clienteService, ILogger<ClientesController> logger) : ControllerBase
    {
        [ProducesResponseType(typeof(ClienteResponse), 201)]
        [HttpPost("criar")]
        public async Task<IActionResult> CriarAsync([FromBody] ClienteRequest request)
        {  
            var response = await clienteService.CriarAsync(request);

            logger.LogInformation(
                $"Operação de cadastro de cliente realizada com sucesso em: {DateTime.Now}. Cliente: " + response
                );

            return StatusCode(201, response);
        }

        [ProducesResponseType(typeof(ClienteResponse), 200)]
        [HttpGet("obter/{email}")]
        public async Task<IActionResult> ObterAsync(string email)
        {
            var response = await clienteService.ObterAsync(email);

            logger.LogInformation(
                $"Operação de consulta de cliente por email realizada com sucesso em: {DateTime.Now}. Cliente: " + response);

            return StatusCode(200, response);
        }
    }
}
