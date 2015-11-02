using System;
using Dominio.Contrato;
using Dominio.Entidade;
using Infraestrutura.IoC.MSUnity;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teste.RefactDDD.Infraestrutura.Repositorios
{
    [TestClass]
    public class TesteUsuarioRepositorio
    {
        #region Atributos
        private IUsuarioRepositorio repositorio;
        private IUnityContainer container;
        #endregion

        #region Testes Unitários
        [TestInitialize]
        public void Inicializar()
        {
            if(container == null)
            {
                container = new UnityContainer();
                ContainerDoUnity.InicializaContainer(container);
            }

            if(repositorio == null)
            {
                repositorio = container.Resolve<IUsuarioRepositorio>();
            }                            
        }

        [TestMethod]
        [Description("Verifica se existe alguma inconsistência com os frameworks presentes no Teste, caso haja, esse teste irá falhar.")]
        [TestCategory("Repositorio - Usuario")]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [Description("Grava o Usuário no banco")]
        [TestCategory("Repositorio - Usuario")]
        public void Gravar()
        {
            Usuario usuario = new Usuario()
            {
                Login = "gsimas",
                NomeCompleto = "Gabriel Simas",
                Senha = "teste,123"
            };

            repositorio.Criar(usuario);
            repositorio.CommitAlteracoes();

            Assert.IsTrue(usuario.Id.HasValue);
        }
        
        #endregion
    }
}
