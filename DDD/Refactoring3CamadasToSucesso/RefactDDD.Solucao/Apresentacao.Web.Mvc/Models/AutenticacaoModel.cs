using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apresentacao.Web.Mvc.Models
{
    public enum Estado
    {
        inativo = 0,
        ativo = 1
    }
    public class UsuarioCadastroModel
    {
        public Nullable<long> Id { get; set; }

        [MaxLength(100)]
        [Required(AllowEmptyStrings = true, ErrorMessage = "É necessário que se entre com o nome completo.")]
        public string NomeCompleto { get; set; }

        [MaxLength(10)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Não é permitido um login em branco.")]
        public string Login { get; set; }
        
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres para a senha")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres para a senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "É necessário se passar sempre o estado do usuário")]
        public Estado Estado { get; set; }        
    }

    public class AutenticacaoModel
    {
        public Nullable<long> Id;
        [MaxLength(10)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Não é permitido um login em branco.")]
        public string Login { get; set; }

        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres para a senha")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracteres para a senha")]
        public string Senha { get; set; }
    }
}