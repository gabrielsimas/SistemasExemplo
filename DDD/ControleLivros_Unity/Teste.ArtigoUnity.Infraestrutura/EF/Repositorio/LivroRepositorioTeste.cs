using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Teste.ArtigoUnity.Infraestrutura.Comum;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using Microsoft.Practices.Unity;
using ArtigoUnity.Dominio.Entidade;
using ArtigoUnity.Infraestrutura.IoC.MicrosoftUnity;

namespace Teste.ArtigoUnity.Infraestrutura.EF.Repositorio
{
    /// <summary>
    /// Summary description for LivroRepositorioTeste
    /// </summary>
    [TestClass]
    public class LivroRepositorioTeste : InfraDeTeste
    {
        #region Atributos

        private TestContext testContextInstance;
        private ILivroRepositorio livroRepositorio;
        private IEditoraRepositorio editoraRepositorio;

        #endregion

        #region Construtores
        public LivroRepositorioTeste()
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

        public IEditoraRepositorio EditoraRepositorio
        {
            get
            {
                if (this.editoraRepositorio == null)
                {
                    editoraRepositorio = this.container.Resolve<IEditoraRepositorio>();
                }
                return this.editoraRepositorio;
            }

            private set
            {
                this.editoraRepositorio = value;
            }
        }

        public ILivroRepositorio LivroRepositorio
        {
            get
            {
                if (this.livroRepositorio == null){
                    livroRepositorio = this.container.Resolve<ILivroRepositorio>();
                }

                return this.livroRepositorio;
            }

            private set
            {
                this.livroRepositorio = value;
            }
        }
        
        #endregion

        #region Testes Unitários

        [TestMethod]
        public void BuscarLivroPorIsbn()
        {

        }

        [TestMethod]
        public void BuscarLivrosPorTrechoDoTitulo()
        {

        }

        [TestMethod]
        public void BuscarLivrosPorGenero()
        {

        }

        [TestMethod]
        public void BuscarLivrosPorAutor()
        {

        }

        [TestMethod]
        public void BuscarLivrosPorEditora()
        {

        }

        [TestMethod]
        [Description("Cadastra um Livro")]
        [TestCategory("Repositorio - LivroRepositorio")]
        public void Cadastrar()
        {
            Nullable<long> id = 1;

            Editora editora = this.EditoraRepositorio.BuscarPorId(1);
            
            Livro livro = new Livro()
            {
                Titulo = "REST: From Research to Practice",
                Autor = "Eric Wilde",
                Genero = "Desenvolvimento de Software",
                Isbn = "978-1-4419-8302-2",
                Sinopse = "This volume provides an overview and an understanding of REST (Representational State Transfer). Discussing the constraints of REST the book focuses on REST as a type of web architectural style. The focus is on applying REST beyond Web applications (i.e., in enterprise environments), and in reusing established and well-understood design patterns when doing so.",
                Editora = editora                
            };

            this.LivroRepositorio.Salvar(livro);
            this.LivroRepositorio.CommitAlteracoes();

            Assert.IsTrue(livro.Id.HasValue);

        }

        [TestMethod]
        public void Alterar()
        {

        }

        [TestMethod]
        public void Excluir()
        {

        }

        [TestMethod]
        public void BuscarPorId()
        {

        }

        [TestMethod]
        public void BuscarTodos()
        {

        }

        [TestMethod]
        public void FiltrarUmPor()
        {

        }

        [TestMethod]
        public void FiltrarVariosPor()
        {

        }

        #endregion
                
    }
}
