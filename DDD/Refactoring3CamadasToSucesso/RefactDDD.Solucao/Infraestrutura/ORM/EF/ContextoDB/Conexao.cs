using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;
using Infraestrutura.ORM.EF.Mapeamento;

namespace Infraestrutura.ORM.EF.ContextoDB
{
    public class Conexao: DbContext
    {
        #region Construtor
        public Conexao()
            : base("sgt")
        {

        }
        #endregion

        #region Propriedades
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        #endregion

        #region Mapeamento de Entidades
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new UsuarioMapeamento());
            modelBuilder.Configurations.Add(new TarefaMapeamento());
        }
        #endregion
    }
}
