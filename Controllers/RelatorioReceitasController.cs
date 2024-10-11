using GerenciamentoFinanceiroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class RelatorioReceitasController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;
        public RelatorioReceitasController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }
        [HttpGet]
        [Route("periodo")]
        public async Task<IActionResult> GetRelatorioReceitas([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
        {
            inicio = DateTime.SpecifyKind(inicio, DateTimeKind.Utc);
            fim = DateTime.SpecifyKind(fim, DateTimeKind.Utc);
            var receitas = await _relatorioService.GetReceitasPorPeriodo(inicio, fim);
            if (!receitas.Any())
            {
                return NotFound("Nenhuma receita encontrada no período especificado.");
            }
            return Ok(receitas);
        }
    }
}
