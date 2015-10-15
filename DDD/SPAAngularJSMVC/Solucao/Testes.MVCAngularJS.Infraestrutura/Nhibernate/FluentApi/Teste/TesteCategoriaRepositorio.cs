using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;
using Teste.MVCAngularJS.Infraestrutura.IoC.Unity;
using MVCAngularJS.Entidade;


namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Teste
{
    /// <summary>
    /// Summary description for TesteCategoriaRepositorio
    /// </summary>
    [TestClass]
    public class TesteCategoriaRepositorio
    {
        #region Atributos

        private TestContext testContextInstance;
        private IUnityContainer unity;
        private ICategoriaRepositorio categoriaRepositorio;
        private IUnitOfWork unidadeDeTrabalho;

        #endregion

        #region Construtores
        public TesteCategoriaRepositorio()
        {
        }

        #endregion

        #region Propriedades

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

        #endregion                                

        #region Testes Unitários

        [TestInitialize]        
        public void Inicializacao()
        {
            this.unity = new UnityContainer();
            UnityResolvedorDeDependencias.InicializaContainer(unity);
            this.categoriaRepositorio = unity.Resolve<ICategoriaRepositorio>();
            this.unidadeDeTrabalho = unity.Resolve<IUnitOfWork>();
        }

        [TestMethod()]
        [TestCategory("CategoriaRepositorio")]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        [TestCategory("CategoriaRepositorio")]
        public void Cadastra()
        {

            unidadeDeTrabalho.IniciarTransacao();

            ICollection<Categoria> categorias = new List<Categoria>();

            Categoria contaDeLuz = new Categoria()
            {
                Nome = "Conta de Luz"
            };

            Categoria contaDeTelefone = new Categoria()
            {
                Nome = "Conta de Telefone"
            };
            
            Categoria contaDeAgua = new Categoria()
            {
                Nome = "Conta de Água"
            };

            categorias.Add(contaDeTelefone);
            categorias.Add(contaDeLuz);
            categorias.Add(contaDeAgua);

            foreach(Categoria categoria in categorias){
                categoriaRepositorio.Salvar(categoria);
            }

            unidadeDeTrabalho.GravaAlteracoesNoBanco();

            Assert.IsTrue(true);

        }

        public void ListarTudo()
        {
            unidadeDeTrabalho.IniciarTransacao();

            unidadeDeTrabalho.GravaAlteracoesNoBanco();
        }
        #endregion
    }
}
