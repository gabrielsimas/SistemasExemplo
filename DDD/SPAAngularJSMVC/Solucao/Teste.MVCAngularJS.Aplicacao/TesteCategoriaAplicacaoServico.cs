using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using MVCAngularJS.Aplicacao.Fachada;
using MVCAngularJS.Infraestrutura.IoC.Unity;
using MVCAngularJS.Aplicacao.Dto;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using Newtonsoft.Json;

namespace Teste.MVCAngularJS.Aplicacao
{
    /// <summary>
    /// Summary description for TesteCategoriaAplicacaoServico
    /// </summary>
    [TestClass]
    public class TesteCategoriaAplicacaoServico
    {
        private IUnityContainer unity;
        private ICategoriaApp categoriaAplicacao;
        private IUnitOfWork uow;

        public TesteCategoriaAplicacaoServico()
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

        [TestInitialize]
        public void Inicializacao()
        {
            this.unity = new UnityContainer();
            UnityResolvedorDeDependencias.InicializaContainer(unity);
            this.categoriaAplicacao = unity.Resolve<ICategoriaApp>();
            this.uow = unity.Resolve<IUnitOfWork>();
        }

        [TestMethod]
        public void ListarTudo()
        {
            ICollection<CategoriaDto> dtos = categoriaAplicacao.BuscarTodos();

            Assert.IsTrue(dtos.Count > 0);
        }

        [TestMethod]
        public void CadastrarCategoria()
        {
            CategoriaDto contaDeTelefone = new CategoriaDto()
            {
                Nome = "Conta do Telefone Celular"
            };

            

            //categoriaAplicacao.BeginTransaction();
                
            categoriaAplicacao.Cadastrar(contaDeTelefone);

            //categoriaAplicacao.Commit();

            Assert.IsTrue(true);
            
        }

        [TestMethod]
        public void ConverteListaPraJSONComFormatacao()
        {
            ICollection<CategoriaDto> dtos = categoriaAplicacao.BuscarTodos();

            String json = JsonConvert.SerializeObject(dtos, Formatting.Indented);

            Assert.IsTrue(!String.IsNullOrEmpty(json));
        }

        [TestMethod]
        public void ConverteListaPraJSONSemFormatacao()
        {
            ICollection<CategoriaDto> dtos = categoriaAplicacao.BuscarTodos();

            String json = JsonConvert.SerializeObject(dtos);

            Assert.IsTrue(!String.IsNullOrEmpty(json));
        }

        [TestMethod]
        public void BuscarPorIdJSON()
        {
            int id = 4;
            CategoriaDto dto = categoriaAplicacao.BuscarPorId(id);

            String json = JsonConvert.SerializeObject(dto);

            Assert.IsTrue(!String.IsNullOrEmpty(json));
        }
    }
}
