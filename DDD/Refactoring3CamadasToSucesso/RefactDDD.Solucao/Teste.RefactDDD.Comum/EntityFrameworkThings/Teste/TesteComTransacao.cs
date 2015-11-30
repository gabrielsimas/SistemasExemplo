using System;
using System.Data.Entity;
using Aplicacao.Servico.Fachada;
using Dominio.Contrato;
using Dominio.Servico.Interfaces;
using Infraestrutura.ORM.EF.ContextoDB;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.RefactDDD.Comum.IoC.MicrosoftUnity;

namespace Teste.RefactDDD.Comum.EntityFrameworkThings.Teste
{
    [TestClass]
    public class TesteComTransacao
    {
        #region Métodos

        private DbContextParaTeste contexto;
        protected DbContextTransaction transacao;

        protected IUnityContainer container;
        protected IUsuarioRepositorio usuarioRepositorio;
        protected ITarefaRepositorio tarefaRepositorio;
        protected IUsuarioServicoDominio usuarioServicoDominio;
        protected ITarefaServicoDominio tarefaServicoDominio;
        protected IUsuarioAplicServico usuarioAplicacaoServico;
        protected ITarefaAplicServico tarefaAplicacaoServico;

        #endregion

        #region Construtor
        public TesteComTransacao()
        {
            this.container = new UnityContainer();
            ContainerDoUnityParaTeste.InicializaContainer(container);
            this.contexto = container.Resolve<DbContextParaTeste>();
        }
        #endregion

        #region Propriedades
        protected DbContextParaTeste Contexto
        {
            get
            {
                if(contexto == null)
                {
                    contexto = container.Resolve<DbContextParaTeste>();
                }

                return contexto;
            }

            private set
            {
                this.contexto = value;
            }
        }
        #endregion

        #region Inicialização e destruição dos testes

        //[AssemblyInitialize]
        //public static void InicializaAssembly(TestContext testContext)
        //{
        //    RefazConfiguracaoDoBanco.SuspenderEstrategiaDeExecucao = true;                        
        //}

        [TestInitialize]
        public void Inicializa()
        {
            transacao = contexto.Database.BeginTransaction();                     
            tarefaRepositorio = container.Resolve<ITarefaRepositorio>();
            usuarioServicoDominio = container.Resolve<IUsuarioServicoDominio>();
            tarefaServicoDominio = container.Resolve<ITarefaServicoDominio>();
            usuarioAplicacaoServico = container.Resolve<IUsuarioAplicServico>();
            tarefaAplicacaoServico = container.Resolve<ITarefaAplicServico>();
        }

        [TestCleanup]
        public void Finalizacao()
        {
            transacao.Rollback();

            if (transacao != null)
            {
                transacao.Dispose();
            }

            if (contexto != null)
            {
                contexto.Dispose();
            }            
        }

        //[AssemblyCleanup]
        //public static void AssemblyEnd()
        //{
        //    RefazConfiguracaoDoBanco.SuspenderEstrategiaDeExecucao = false;
        //}

        #endregion

    }
}
