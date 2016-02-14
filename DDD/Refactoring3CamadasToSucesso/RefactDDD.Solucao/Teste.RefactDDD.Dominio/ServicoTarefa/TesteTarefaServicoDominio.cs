using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.RefactDDD.Comum.EntityFrameworkThings.Teste;
using Dominio.Entidade;

namespace Teste.RefactDDD.Dominio.ServicoTarefa
{
    /// <summary>
    /// Summary description for TesteTarefaServicoDominio
    /// </summary>
    [TestClass]
    public class TesteTarefaServicoDominio: TesteComTransacao
    {
        public TesteTarefaServicoDominio()
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
        
        [TestMethod]
        [TestCategory("Dominio - Serviço - Tarefa")]
        public void CadastrarNovaTarefa()
        {
            Tarefa tarefa = new Tarefa()
            {
                DataDaEntrega = DateTime.Now.AddDays(40D),
                Descricao = "Teste Unitário de inserção de tarefa",
                Nome = "Teste de Inserção",
                Estado = EstadoTarefa.EmAberto,
                IdUsuario = 9,
                Usuario = new Usuario()
                {
                    Login = "teste",
                    NomeCompleto = "teste",
                    Senha = "teste",
                    Status = Status.ativo                    
                }
  
            };

            this.tarefaServicoDominio.CadastrarTarefa(tarefa);            

            Assert.IsTrue(tarefa.Id.HasValue);
        }
    }
}
