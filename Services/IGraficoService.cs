using GerenciamentoFinanceiroAPI.DTOs;

namespace GerenciamentoFinanceiroAPI.Services
{
    public interface IGraficoService
    {
        Task<IEnumerable<ResumoMensalDto>> GetDespesasMensais();
        Task<IEnumerable<ResumoMensalDto>> GetReceitasMensais();
        Task<IEnumerable<ResumoMensalDto>> GetResumoMensal();
    }
}
