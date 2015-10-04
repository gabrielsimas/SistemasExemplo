using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Infraestrutura.EF.Mapeamento.Comum;

namespace ArtigoUnity.Infraestrutura.EF.Mapeamento
{
    public class MapeamentoLivro: EntityTypeConfiguration<LivroId>
    {
        public MapeamentoLivro()
        {
            ToTable("Livro");

            HasKey(l => l.Id);

            Property(l => l.Autor).HasColumnName("autor").HasMaxLength(100).IsRequired();
            Property(l => l.Genero).HasColumnName("genero").HasMaxLength(100).IsRequired();
            Property(l => l.Isbn).HasColumnName("isbn").HasMaxLength(100).IsRequired();
            Property(l => l.Sinopse).HasColumnName("sinopse").HasMaxLength(500);
            Property(l => l.Titulo).HasColumnName("titulo").HasMaxLength(100).IsRequired();
            Property(l => l.IdEditora).HasColumnName("idEditora");

            HasRequired(l => l.Editora).WithMany(e =>(ICollection<LivroId>) e.Livros).HasForeignKey(l => l.IdEditora);
        }

    }
}
