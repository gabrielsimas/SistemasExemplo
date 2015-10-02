using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Infraestrutura.Configuracao.EF.FonteDeDados
{
    public class ContextoDeBanco: DbContext
    {
        #region Atributos

        #endregion

        #region Construtores
        public ContextoDeBanco()
            :base(ConfigurationManager.ConnectionStrings["ControleContatos"].ConnectionString)
        {
            
        }
        #endregion

        #region Propriedades

        public DbSet<Contato> Contato { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
        public DbSet<Telefone> Telefone { get; set; }
        public DbSet<TipoRedeSocial> TipoRedeSocial { get; set; }
        public DbSet<TipoTelefone> TipoTelefone { get; set; }

        #endregion

        #region Métodos de Contexto de Banco de Dados

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ContatoConfiguration());
            modelBuilder.Configurations.Add(new RedeSocialConfiguration());
            modelBuilder.Configurations.Add(new TelefoneConfiguration());
            modelBuilder.Configurations.Add(new TipoTelefoneConfiguration());
            modelBuilder.Configurations.Add(new TipoRedeSocialConfiguration());

        }

        #endregion
    }
}
