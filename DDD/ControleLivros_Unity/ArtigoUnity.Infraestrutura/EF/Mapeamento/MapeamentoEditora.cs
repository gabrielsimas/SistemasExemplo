using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;

namespace ArtigoUnity.Infraestrutura.EF.Mapeamento
{
    public class MapeamentoEditora : EntityTypeConfiguration<Editora>
    {
        public MapeamentoEditora()
        {
            ToTable("Editora");

            HasKey(e => e.Id);

            Property(e => e.Nome);            
        }
    }
}
