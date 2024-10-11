using GerenciamentoFinanceiroAPI.Models;

namespace GerenciamentoFinanceiroAPI.Services
{
    public interface IRelatorioService
    {
        Task<IEnumerable<Receitas>> GetReceitasPorPeriodo(DateTime inicio, DateTime fim);
        Task<IEnumerable<Despesas>> GetDespesasPorPeriodo(DateTime inicio, DateTime fim);
    }
    
}
