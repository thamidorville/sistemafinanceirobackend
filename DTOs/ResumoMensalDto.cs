using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiroAPI.DTOs
{
    public class ResumoMensalDto
    {
        [Required(ErrorMessage = "O mês é obrigatório")]
        [MinLength(1, ErrorMessage = "O mês não pode ser vazio.")]
        public string Mes { get; set; } = string.Empty;
        public decimal TotalDespesas { get; set; } = 0;
        public decimal TotalReceitas { get; set; } = 0;
    }
}
