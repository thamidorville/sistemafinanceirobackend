using GerenciamentoFinanceiroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class RelatorioDespesasController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioDespesasController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        [HttpGet]
        [Route("periodo")]
        public async Task<IActionResult> GetRelatorioDespesas([FromQuery] DateTime inicio, [FromQuery] DateTime fim)
        {
            inicio = DateTime.SpecifyKind(inicio, DateTimeKind.Utc);
            fim = DateTime.SpecifyKind(fim, DateTimeKind.Utc);
            var despesas = await _relatorioService.GetDespesasPorPeriodo(inicio, fim);
            if (!despesas.Any())
            {
                return NotFound("Nenhuma despesa encontrada no período selecionado.");
            }
            return Ok(despesas);
        }
    }
}

