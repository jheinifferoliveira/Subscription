using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subscription.Domain.Entities;
using Subscription.Domain.Enums;
using Subscription.Infra.Data.Contexts;

namespace Subscription.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanosController(AppDbContext context) : ControllerBase
    {

        [HttpGet("listar")]
        public async Task<IActionResult> ConsultarAsync(int page = 1, int pageSize = 10)
        {
            var query = context.Set<Plano>().AsQueryable();

            var total = await query.CountAsync();

            var planos = await query
                .OrderBy(p => p.Nome)
                .Skip((page - 1) * pageSize) //página a partir do qual iremos começar 
                .Take(pageSize) // total de registros
                .Select(p => new
                {
                    id = p.Id,
                    nome = p.Nome.ToUpper(),
                    valorMensal = p.ValorMensal,
                    periodicidade = p.Periodicidade
                })
                .ToListAsync();

            return Ok(new
            {
                page,
                pageSize,
                total,
                data = planos
            });
        }
    }
}
