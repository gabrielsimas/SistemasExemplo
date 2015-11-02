using System;
using System.Collections.Generic;
using Dominio.Contrato;
using Dominio.Entidade;
using Infraestrutura.IoC.MSUnity;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teste.RefactDDD.Infraestrutura.Repositorios
{
    [TestClass]
    public class TesteTarefaRepositorio
    {
        #region Atributos
        private ITarefaRepositorio repositorio;
        private IUsuarioRepositorio usuarioRepositorio;
        private IUnityContainer container;
        #endregion

        #region Testes Unitários

        [TestInitialize]                
        public void Inicializacao()
        {
            if (container == null)
            {
                container = new UnityContainer();
                ContainerDoUnity.InicializaContainer(container);
            }

            if (repositorio == null)
            {
                repositorio = container.Resolve<ITarefaRepositorio>();
            }

            if (usuarioRepositorio == null)
            {
                usuarioRepositorio = container.Resolve<IUsuarioRepositorio>();
            }
        }

        [TestMethod]
        [Description("Verifica se existe alguma inconsistência com os frameworks presentes no Teste, caso haja, esse teste irá falhar.")]
        [TestCategory("Repositorio - Tarefa")]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Description("Cria uma tarefa")]
        [TestCategory("Repositorio - Tarefa")]
        public void Criar()
        {
            Nullable<Int64> idUsuario = 2;
            //Usuario usuario = usuarioRepositorio.FiltrarSimplesPor(u => u.Id.Equals(idUsuario));
            Tarefa tarefa = new Tarefa()
            {
                DataDaEntrega = new DateTime(2015,11,2),
                Descricao = "Entregar o artigo de Refactoring para o Joel.",
                Estado = EstadoTarefa.EmAberto,
                Nome = "Entregar artigo de refactoring",
                IdUsuario = idUsuario
            };

            repositorio.Criar(tarefa);
            repositorio.CommitAlteracoes();

            Assert.IsTrue(tarefa.Id.HasValue);
        }

        [TestMethod]
        [Description("Altera uma tarefa já cadastrada")]
        [TestCategory("Repositorio - Tarefa")]
        public void Editar()
        {
            Nullable<long> idTarefa = 2;
            Tarefa tarefaDoBanco;
            string novaDescricao = "Entregar o artigo de Refactoring para o Editor da .NET Magazine.";

            //Localiza a Tarefa a ser editada
            tarefaDoBanco = repositorio.FiltrarSimplesPor(t => t.Id.Equals(idTarefa));

            //Altera o valor da entidade
            tarefaDoBanco.Descricao = novaDescricao;

            //Altera no banco
            repositorio.Editar(tarefaDoBanco);
            repositorio.CommitAlteracoes();
                
            //Recupera novamente o valor do objeto           
            tarefaDoBanco = repositorio.FiltrarSimplesPor(t => t.Id.Equals(idTarefa));

            Assert.IsTrue(tarefaDoBanco.Descricao.Equals(novaDescricao));
        }

        [TestMethod]
        [Description("Exclui uma Tarefa")]
        [TestCategory("Repositorio - Tarefa")]
        public void Excluir()
        {
            Nullable<long> idTarefaAExcluir = 3;

            //Localiza o objeto a ser excluído
            Tarefa tarefaExcluir = repositorio.FiltrarSimplesPor(t => t.Id.Equals(idTarefaAExcluir));

            if (tarefaExcluir.Id.HasValue)
            {
                repositorio.Excluir(tarefaExcluir);
                repositorio.CommitAlteracoes();
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail(String.Format("Não existe nenhuma tarefa de código {0} na base de dados!",idTarefaAExcluir));
            }

        }

        [TestMethod]
        [TestCategory("Repositorio - Tarefa")]
        public void FiltrarCompostoPorTarefaFinalizada()
        {
            ICollection<Tarefa> tarefasFinalizadas = repositorio.FiltrarCompostoPor(t => t.Estado.Equals(EstadoTarefa.Executada));

            if (tarefasFinalizadas != null && tarefasFinalizadas.Count > 0)
            {
                Assert.IsTrue(tarefasFinalizadas.Count > 0);
            }
            else
            {
                Assert.Inconclusive("Não existem tarefas finalizadas.");
            }
        }

        [TestMethod]
        [TestCategory("Repositorio - Tarefa")]
        public void FiltrarSimplesPorIdTarefa()
        {
            Nullable<long> idTarefa = 2;
            Tarefa tarefa = repositorio.FiltrarSimplesPor(t => t.Id.Equals(idTarefa));

            Assert.IsTrue(tarefa.Id.HasValue);
        }

        #endregion
    }
}
