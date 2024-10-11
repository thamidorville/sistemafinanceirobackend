using GerenciamentoFinanceiroAPI.DTOs;
using GerenciamentoFinanceiroAPI.Data;
using Microsoft.EntityFrameworkCore;


namespace GerenciamentoFinanceiroAPI.Services
{
    public class GraficoService(AppDbContext context) : IGraficoService
    {
        private readonly AppDbContext _context = context;
        public async Task<IEnumerable<ResumoMensalDto>> GetDespesasMensais()
        {
            try
            {
                var despesas = await _context.Despesas
                .GroupBy(d => new { d.Data.Year, d.Data.Month })
                .ToListAsync();

                var resultado = despesas.Select(g => new ResumoMensalDto
                {
                    Mes = $"{g.Key.Month:D2}/{g.Key.Year}",
                    TotalDespesas = g.Sum(d => d.Valor),
                    TotalReceitas = 0
                });
                return resultado;
            } 
            catch (Exception ex) 
            {
                Console.WriteLine($"Erro ao obter Despesas Mensais: {ex.Message}");
                return Enumerable.Empty<ResumoMensalDto>();
            }

        }
        public async Task<IEnumerable<ResumoMensalDto>> GetReceitasMensais()
        {
            try
            {
                var receitas = await _context.Receitas
               .GroupBy(r => new { r.Data.Year, r.Data.Month })
               .ToListAsync();
                var resultado = receitas.Select(g => new ResumoMensalDto
                {
                    Mes = $"{g.Key.Month:D2}/{g.Key.Year}",
                    TotalReceitas = g.Sum(r => r.Valor),
                    TotalDespesas = 0
                });
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter Receitas Mensais: {ex.Message}");
                return Enumerable.Empty<ResumoMensalDto>();
            }
           
        }
        public async Task<IEnumerable<ResumoMensalDto>> GetResumoMensal()
        {
            try
            {
                var despesas = await GetDespesasMensais();
                var receitas = await GetReceitasMensais();

                var resumoMensal = despesas.Concat(receitas)
                    .GroupBy(r => r.Mes)
                    .Select(g => new ResumoMensalDto
                    {
                        Mes = g.Key,
                        TotalDespesas = g.Sum(r => r.TotalDespesas),
                        TotalReceitas = g.Sum(r => r.TotalReceitas)
                    });

                return resumoMensal;
            }
            catch (Exception ex ) 
            {
                Console.WriteLine($"Erro ao obter Resumo Mensal: {ex.Message}");
                return Enumerable.Empty<ResumoMensalDto>();
            }

          
        }

    }
}


