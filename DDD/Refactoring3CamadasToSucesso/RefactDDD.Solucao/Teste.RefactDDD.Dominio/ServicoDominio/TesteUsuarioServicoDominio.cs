using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.RefactDDD.Comum.EntityFrameworkThings.Teste;
using Microsoft.Practices.Unity;
using Dominio.Entidade;

namespace Teste.RefactDDD.Dominio.ServicoDominio
{
    /// <summary>
    /// Summary description for TesteUsuarioServicoDominio
    /// </summary>
    [TestClass]
    public class TesteUsuarioServicoDominio: TesteComTransacao
    {        
        public TesteUsuarioServicoDominio()            
        {
            
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

        [TestMethod]
        [TestCategory("Dominio - Serviço - Usuario")]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Description("Cadastra um novo usuário")]
        [TestCategory("Dominio - Serviço - Usuario")]
        public void CadastrarUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Login = "lhelena",
                NomeCompleto = "Livia Helena Barcia Simas",
                Senha = "teste,123",
                Status = Status.ativo
            };

            usuarioServicoDominio.CadastrarNovoUsuario(usuario);
            usuarioServicoDominio.CommitAlteracoes();

            Assert.IsTrue(usuario.Id.HasValue,usuario.ToString());
        }

        [TestMethod]
        [Description("Autentica um usuário")]
        [TestCategory("Dominio - Serviço - Usuario")]
        public void AutenticarUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Login = "lhelena",
                NomeCompleto = "Livia Helena Barcia Simas",
                Senha = "teste,123",
                Status = Status.ativo
            };

            usuarioServicoDominio.CadastrarNovoUsuario(usuario);
            usuarioServicoDominio.CommitAlteracoes();

            Usuario usuarioParaAutenticacao = new Usuario()
            {
                Login = "lhelena",
                Senha = "teste,123"
            };

            Assert.IsTrue(usuarioServicoDominio.AutenticarUsuario(usuarioParaAutenticacao));
        }
    }
}
