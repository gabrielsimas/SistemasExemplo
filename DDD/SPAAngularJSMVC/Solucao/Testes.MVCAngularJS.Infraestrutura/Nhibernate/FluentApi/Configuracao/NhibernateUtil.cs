using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Configuracao
{
    public class NhibernateUtil: IUnitOfWork,IDisposable
    {
        #region Atributos
        private static readonly ISessionFactory fabricaDeSessao;                
        private ITransaction transacao;

        #endregion

        #region Singleton
        static NhibernateUtil()
        {
            if (fabricaDeSessao == null)
            {
                fabricaDeSessao = Fluently.Configure()
                            .Database(
                                MsSqlConfiguration.MsSql2008
                                    .Provider<NHibernate.Connection.DriverConnectionProvider>()
                                    .Dialect<NHibernate.Dialect.MsSql2008Dialect>()
                                    .Driver<NHibernate.Driver.Sql2008ClientDriver>()
                                    .ShowSql()
                                    .ConnectionString(stringConexao => stringConexao.FromConnectionStringWithKey("MVCAngularJs")
                                    )
                            )
                            .Mappings(
                                m =>
                                {
                                    foreach (string nomeAssembly in MapeamentoDeAssembliesDoFluentNHibernate)
                                    {
                                        m.AutoMappings.Add
                                        (
                                            AutoMap.Assembly
                                            (
                                                Assembly.Load(nomeAssembly)
                                            ).Conventions
                                                .Setup(
                                                    convencao =>
                                                    {
                                                        convencao.Add<ConventionCustomChaveEstrangeira>();
                                                        convencao.Add<AutoMapeiaEnums>();

                                                    }
                                                )
                                        );
                                    }
                                })
                                .BuildSessionFactory();

            }
        }

        public NhibernateUtil()
        {
            Sessao = fabricaDeSessao.OpenSession();
        }
        #endregion

        #region Propriedades
        public ISession Sessao { get; private set; }              

        public static string[] MapeamentoDeAssembliesDoFluentNHibernate {
            get
            {
                return ConfigurationManager.AppSettings["AssembliesComMapeamento"].Split(',');
            }
        }

        public String TipoMapeamento { get; set; }
                
        #endregion        
        
        #region Unit of Work
        public void IniciarTransacao()
        {
            transacao = Sessao.BeginTransaction();
        }

        public void GravaAlteracoesNoBanco()
        {
            try
            {
                transacao.Commit();
            }
            catch
            {
                
                throw;
            }
        }
        #endregion

        /// <summary>
        /// Dispose Buraco Negro
        /// Se rodar esse dispose, é capaz de gerar um buraco negro que
        /// pode desligar a máquina
        /// </summary>
        public void Dispose()
        {
            //Fecha a Transacao
            if (transacao != null && transacao.IsActive)
            {                                
                transacao.Dispose();
                transacao = null;
            }

            if (Sessao != null &&  Sessao.IsOpen)
            {                
                Sessao.Close();
                Sessao.Dispose();
                Sessao = null;
            }

            if ( fabricaDeSessao != null && !fabricaDeSessao.IsClosed)
            {
                fabricaDeSessao.Close();
                fabricaDeSessao.Dispose();
            }                                  
        }
    }
}
