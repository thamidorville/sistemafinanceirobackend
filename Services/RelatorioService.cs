using GerenciamentoFinanceiroAPI.Models;
using Microsoft.EntityFrameworkCore;
using GerenciamentoFinanceiroAPI.Data;


namespace GerenciamentoFinanceiroAPI.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Receitas>> GetReceitasPorPeriodo(DateTime inicio, DateTime fim)
        {
            return await _context.Receitas
                .Where(r => r.Data >= inicio && r.Data <= fim)
                .ToListAsync();
        }

        public async Task<IEnumerable<Despesas>> GetDespesasPorPeriodo(DateTime inicio, DateTime fim)
        {
            return await _context.Despesas
                .Where(d => d.Data >= inicio && d.Data <= fim)
                .ToListAsync();
        }
    }
}

