using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Infraestrutura.EF.Mapeamento;

namespace ArtigoUnity.Infraestrutura.EF.ContextoBD
{
    public class ContextoDb: DbContext
    {
        public ContextoDb()
            : base(ConfigurationManager.ConnectionStrings["artigounity"].ConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapeamentoEditora());
            modelBuilder.Configurations.Add(new MapeamentoLivro());
        }

        public DbSet<Livro> Livro { get; set; }
        public DbSet<Editora> Editora { get; set; }
    }
}

