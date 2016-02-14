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
