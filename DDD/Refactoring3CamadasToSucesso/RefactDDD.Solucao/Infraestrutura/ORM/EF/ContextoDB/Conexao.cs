using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;
using Infraestrutura.ORM.EF.Mapeamento;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Infraestrutura.ORM.EF.ContextoDB
{
    public class Conexao: DbContext, IUnitOfWork, IDisposable
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
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new UsuarioMapeamento());
            modelBuilder.Configurations.Add(new TarefaMapeamento());
        }
        #endregion

        #region Unit of Work
        public void CommitAlteracoes()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade \"{0}\" no estado \"{1}\" tem os seguintes erros de validacao:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Propriedade: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                
                throw;
            }
            
        }

        public void CommitaERefresha()
        {
            Boolean falhouAoSalvar = false;

            do
            {
                try
                {
                    base.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    falhouAoSalvar = true;

                    ex.Entries.ToList()
                        .ForEach(valores =>
                        {
                            valores.OriginalValues.SetValues(valores.GetDatabaseValues());
                        });
                }
            } while (falhouAoSalvar);
        }

        public void DesfazAlteracoes()
        {
            base.ChangeTracker.Entries()
                              .ToList()
                              .ForEach(estados => estados.State = EntityState.Unchanged);
        }
        #endregion        
    }
}
