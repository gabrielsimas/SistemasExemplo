using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Aplicacao.Servico.Fachada;
using Infraestrutura.IoC.MSUnity;
using Aplicacao.Dto;

namespace Teste.RefactDDD.Aplicacao
{
    /// <summary>
    /// Summary description for TarefaAplicServicoTeste
    /// </summary>
    [TestClass]
    public class TarefaAplicServicoTeste
    {
        private IUnityContainer container = new UnityContainer();
        private ITarefaAplicServico tarefaAplicacaoServico;
        public TarefaAplicServicoTeste()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestInitialize]
        public void Inicializar()
        {
            ContainerDoUnity.InicializaContainer(container);
            tarefaAplicacaoServico = container.Resolve<ITarefaAplicServico>();
            
        }

        [TestMethod]
        [TestCategory("Aplicação - Tarefa")]
        [Description("Verifica se o Container de Injeção de dependências está funcional, bem como outros serviços de infra")]
        public void Integracao()
        {
            Assert.IsTrue(tarefaAplicacaoServico != null);
        }

        [TestMethod]
        [TestCategory("Aplicação - Tarefa")]
        public void ListaTodasAsTarefasDoUsuarioTeste()
        {
            //Usuário de teste
            int idUsuario = 9;

            ICollection<TarefaDto> dtos = new List<TarefaDto>();
            TarefaDto dto = new TarefaDto() { Usuario = new UsuarioDto() { Id = idUsuario} };

            dtos = tarefaAplicacaoServico.ListarTodasAsTarefasDoUsuario(dto);

            Assert.IsTrue(dtos.Count > 0);                        
        }

        [TestMethod]
        [TestCategory("Aplicação - Tarefa")]
        public void ListaTarefasVencidas()
        {
            //Usuário de teste
            int idUsuario = 9;

            ICollection<TarefaDto> dtos = new List<TarefaDto>();
            TarefaDto dto = new TarefaDto() { Usuario = new UsuarioDto() { Id = idUsuario } };

            dtos = tarefaAplicacaoServico.ListarTarefasNaoConcluidas(dto);

            Assert.IsTrue(dtos.Count > 0);
        }

        [TestMethod]
        [TestCategory("Aplicação - Tarefa")]
        public void ListaTarefasAVencer()
        {
            //Usuário de teste
            int idUsuario = 9;

            ICollection<TarefaDto> dtos = new List<TarefaDto>();
            TarefaDto dto = new TarefaDto() { Usuario = new UsuarioDto() { Id = idUsuario } };

            dtos = tarefaAplicacaoServico.ListarTarefasAVencer(dto);

            Assert.IsTrue(dtos.Count > 0);
        }

        [TestMethod]
        [TestCategory("Aplicação - Tarefa")]
        public void CadastrarNovaTarefa()
        {
            Nullable<long> idUsuario = 9;

            TarefaDto dto = new TarefaDto()
            {
                DataDaEntrega = DateTime.Now.AddDays(20),
                Descricao = "Teste de Inserção de Tarefa",
                Estado = EstadoTarefa.EmAberto,
                IdUsuario = idUsuario.Value,
                Nome = "Teste de Tarefa"
            };

            this.tarefaAplicacaoServico.CadastrarTarefa(dto);

            Assert.IsTrue(dto.Id.HasValue);
            
        }
    }
}
