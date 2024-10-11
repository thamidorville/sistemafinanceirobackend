using GerenciamentoFinanceiroAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoFinanceiroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class GraficoController : ControllerBase
    {
        private readonly IGraficoService _graficoService;

        public GraficoController(IGraficoService graficoService)
        {
            _graficoService = graficoService;
        }

        [HttpGet("despesas-mensais")]
        public async Task<IActionResult> GetDespesasMensais()
        {
            var despesas = await _graficoService.GetDespesasMensais();
            if (!despesas.Any())
            {
                return NotFound("Nenhuma despesa encontrada para os meses especificados.");
            }
            return Ok(despesas);
        }

        [HttpGet("receitas-mensais")]
        public async Task<IActionResult> GetReceitasMensais()
        {
            var receitas = await _graficoService.GetReceitasMensais();
            if (!receitas.Any())
            {
                return NotFound("Nenhuma receita encontrada para os meses especificados.");
            }
            return Ok(receitas);
        }
        [HttpGet("resumo-mensal")]
        public async Task<IActionResult> GetResumoMensal()
        {
            var resumo = await _graficoService.GetResumoMensal();
            if (!resumo.Any()){
                return NotFound("Nenhum resumo mensal encvontrado.");
            }
            return Ok(resumo);
        }
    }

}
