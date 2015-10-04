using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using Teste.ArtigoUnity.Infraestrutura.Comum;
using Microsoft.Practices.Unity;
using ArtigoUnity.Dominio.Entidade;

namespace Teste.ArtigoUnity.Infraestrutura.EF.Repositorio
{
    /// <summary>
    /// Summary description for EditoraRepositorioTeste
    /// </summary>
    [TestClass]
    public class EditoraRepositorioTeste: InfraDeTeste
    {               
        #region Atributos

        private TestContext testContextInstance;
        private IEditoraRepositorio repositorio;

        #endregion 

        #region Construtores
        public EditoraRepositorioTeste()
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

        #region Ações de Apoio
            
        #endregion

        #region Testes Unitários
        public IEditoraRepositorio Repositorio
        {
            get
            {               
                if(this.repositorio == null){
                    this.repositorio = this.container.Resolve<IEditoraRepositorio>();
                }
                return this.repositorio;
            }

            set
            {
                this.repositorio = value;
            }
        }
        #endregion

        

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
        public void SalvaEditora()
        {
            Nullable<long> id;
            Editora editora = new Editora()
            {                
                Nome = "Apress"             
            };

            Repositorio.Salvar(editora);

            Repositorio.CommitAlteracoes();

            Assert.IsTrue(editora.Id.HasValue);
        }
    }
}
