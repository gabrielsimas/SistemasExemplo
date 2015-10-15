using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Dominio.Repositorio.Interfaces.Base;
using ArtigoUnity.Infraestrutura.EF.Mapeamento;
using ArtigoUnity.Infraestrutura.EF.Repositorio.Interfaces;

namespace ArtigoUnity.Infraestrutura.EF.ContextoBD
{
    public class ContextoDb: DbContext, IUnitOfWork
    {
        #region Construtor
        public ContextoDb()
            : base(ConfigurationManager.ConnectionStrings["artigounity"].ConnectionString)
        {

        }

        #endregion

        #region Propriedades
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Editora> Editora { get; set; }

        #endregion                       

        #region Operações Transacionais

        public void CommitAlteracoes()
        {
            base.SaveChanges();
        }

        public void CommitaERefresha()
        {
            Boolean falhouAoSalvar = false;

            do
            {
                try
                {

                }
                catch (DbUpdateConcurrencyException ex)
                {
                    falhouAoSalvar = true;

                    ex.Entries.ToList()
                        .ForEach(entry =>
                        {
                            entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                        });
                }
            } while (falhouAoSalvar);
        }

        public void DesfazAlteracoes()
        {
            // Coloca todas as entidades envolvidas na transação
            //a ser desfeita com o estado de "não modificada (unchanged)"
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(entry => entry.State = EntityState.Unchanged);
        }

        #endregion
        
        #region Sobrescritas do Papai DbContext
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();

            modelBuilder.Configurations.Add(new MapeamentoEditora());
            modelBuilder.Configurations.Add(new MapeamentoLivro());
        }

        #endregion
    }
}

