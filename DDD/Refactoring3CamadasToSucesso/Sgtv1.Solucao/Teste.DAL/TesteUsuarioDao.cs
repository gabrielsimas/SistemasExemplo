using System;
using DAL.Entidades;
using DAL.Persistencia;
using DAL.Persistencia.DataSource;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teste.DAL
{
    [TestClass]
    public class TesteUsuarioDao
    {
        #region Atributos

        private ConexaoDeDados conexao;
        private UsuarioDao dao;

        #endregion

        #region Testes Unitários        

        [TestMethod]
        public void Integracao()
        {
            Assert.IsTrue(conexao != null);
        }        

        [TestMethod]
        [Description("Verifica a geração de MD5 para a senha.")]
        [TestCategory("DAL - UsuarioDao - Senha")]
        public void VerificarMd5()
        {
            string senha = "teste,123";
            string senhaNova = String.Empty;

            using(dao = new UsuarioDao())
            {
                senhaNova = dao.GeraHashMd5(senha);
            }                       

            Assert.IsTrue(true);            
        }

        [TestMethod]
        [Description("Insere um usuário na base de dados")]
        [TestCategory("DAL - UsuarioDao - CRUD")]
        public void GravarUsuario()
        {
            Usuario usuario = new Usuario()
            {
                Login = "gsimas",
                NomeCompleto = "Gabriel Simas",
                Senha = "teste,123",
                Status = 1             
            };

            using(dao = new UsuarioDao())
            {
                dao.Gravar(usuario);
            }

            Assert.IsTrue(usuario.Id > 0);
        }

        [TestMethod]
        [Description("Verifica se a verificação de usuário e senha está funcionando OK")]
        [TestCategory("DAL - UsuarioDao - Métodos Gerais")]
        public void ValidaUsuarioESenha()
        {
            //Entrada de dados
            String login = "gsimas";
            String senha = "teste,123";
            Usuario usuario;
            
            using(dao = new UsuarioDao())
            {                
                String senhaHash = dao.GeraHashMd5(senha);

                usuario = dao.BuscarLogin(login);

                if (usuario.Senha.Equals(senhaHash))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsTrue(false);
                }

            }

        }

        #endregion        

    }
}
