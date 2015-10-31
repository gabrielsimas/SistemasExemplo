using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;
using Infraestrutura.ORM.EF.Mapeamento.Comum;

namespace Infraestrutura.ORM.EF.Mapeamento
{
   public class TarefaMapeamento: EntityTypeConfiguration<TarefaId>
   {
       public TarefaMapeamento()
       {
           ToTable("TB_TAREFA");

           HasKey(t => t.Id);
           Property(t => t.Id).HasColumnName("cod_tarefa");
           Property(t => t.Nome).HasColumnName("nome").HasMaxLength(100).IsRequired();
           Property(t => t.DataDaEntrega).HasColumnName("dataentrega").IsRequired();
           Property(t => t.Descricao).HasColumnName("descricao").HasMaxLength(100);
           Property(t => t.Estado).HasColumnName("estado");

           HasRequired(t => t.Usuario).WithMany(u => (ICollection<TarefaId>)u.Tarefas).HasForeignKey(t => t.IdTarefa);
       }
   }
}
