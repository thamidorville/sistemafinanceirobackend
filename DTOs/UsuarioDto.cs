﻿using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiroAPI.DTOs
{
    public class UsuarioDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")] 
        public string Password { get; set; } = string.Empty;
    }

}
