using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entidades
{
    public enum EstadoTarefa
    {
        EmAberto = 0,
        Executada = 1
    }

    [Table("TB_TAREFA")]
    public class Tarefa
    {
        #region Construtores

        public Tarefa()
        {

        }

        #endregion
        #region Propriedades

        [Key]
        [Column("cod_tarefa")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Column("nome")]
        [Required(AllowEmptyStrings=false,ErrorMessage="É necessário que a tarefa tenha um nome.")]
        [MinLength(6,ErrorMessage="Minimo de 6 caracteres para o nome.")]
        [MaxLength(100,ErrorMessage="Maximo de 100 caracteres para o nome.")]
        public virtual String Nome {get; set;}

        [Column("dataEntrega")]
        [Required(AllowEmptyStrings=false,ErrorMessage="É necessário que a tarefa contenha uma data de entrega.")]        
        public virtual DateTime DataDeEntrega { get; set; }

        [Column("descricao")]
        [Required(AllowEmptyStrings=false,ErrorMessage="É necessário que a tarefa contenha uma descrição.")]
        public virtual String Descricao { get; set; }

        [Column("estado")]        
        public virtual EstadoTarefa Estado { get; set; }
        
        [Column("cod_usuario")]
        public virtual int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]                
        public virtual Usuario Usuario { get; set; }

        #endregion
    }
}
