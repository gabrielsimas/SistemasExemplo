using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Configuracao;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Teste
{
    /// <summary>
    /// Teste da geração automatica de Configuração pelo NHibernate Fluent
    /// </summary>
    [TestClass]
    public class AutoMappingTeste
    {
        #region Atributos

        private TestContext testContextInstance;
        private NhibernateUtil fabrica;

        #endregion

        #region Construtores
        public AutoMappingTeste()
        {
            //
            // TODO: Add constructor logic here
            //
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
            fabrica = new NhibernateUtil();
        }

        [TestCleanup]
        public void LimpaTudoETermina()
        {
            fabrica.Dispose();
        }

        [TestMethod]
        public void Integracao()
        {                        
            Assert.IsTrue(fabrica.Sessao.IsOpen);
        }

        #region Categoria

        #endregion

        #region Consumo

        #endregion

        #region Unidade

        #endregion

        #endregion

    }
}
