using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;

namespace Infraestrutura.ORM.EF.Mapeamento
{
    public class UsuarioMapeamento: EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapeamento()
        {
            ToTable("TB_USUARIO");

            HasKey(u => u.Id);

            Property(u => u.Id).HasColumnName("cod_usuario");
            Property(u => u.Login).HasColumnName("login").HasMaxLength(20).IsRequired();
            Property(u => u.NomeCompleto).HasColumnName("nomecompleto").HasMaxLength(100).IsRequired();
            Property(u => u.Senha).HasColumnName("senha").HasMaxLength(500).IsRequired();
            Property(u => u.Status).HasColumnName("estado");            

        }
    }
}
