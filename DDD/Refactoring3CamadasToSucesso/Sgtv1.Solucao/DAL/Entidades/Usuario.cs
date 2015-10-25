using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entidades
{
    [Table("TB_USUARIO")]
    public class Usuario
    {
        #region Construtor
        public Usuario()
        {

        }

        #endregion
        #region Propriedades

        [Key]
        [Column("cod_usuario")]        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Column("nomecompleto")]
        [MaxLength(100)]
        [Required(AllowEmptyStrings=true,ErrorMessage="É necessário que se entre com o nome completo.")]
        public virtual String NomeCompleto { get; set; }

        [Column("login")]
        [MaxLength(10)]
        [Required(AllowEmptyStrings=false,ErrorMessage="Não é permitido um login em branco.")]
        public virtual String Login { get; set; }

        [Column("senha")]        
        [MinLength(3,ErrorMessage="Mínimo de 3 caracteres para a senha")]
        [MaxLength(100,ErrorMessage="Máximo de 100 caracteres para a senha")]
        public virtual String Senha { get; set; }

        [Column("estado")]
        [Required(ErrorMessage="É necessário se passar sempre o estado do usuário")]
        public virtual int Status { get; set; }
                
        public virtual ICollection<Tarefa> Tarefas { get; set; }

        #endregion
    }
}
