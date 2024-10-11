using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiroAPI.Models
{
    public class Receitas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Descricao { get; set; } = string.Empty; 

        public decimal Valor { get; set; }

        public DateTime Data { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string Categoria { get; set; } = string.Empty; 
    }

}
