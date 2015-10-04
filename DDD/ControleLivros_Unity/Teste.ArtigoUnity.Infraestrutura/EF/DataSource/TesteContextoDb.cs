using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using ArtigoUnity.Infraestrutura.EF.ContextoBD;
using System.Data.Entity;
using Teste.ArtigoUnity.Infraestrutura.Comum;

namespace Teste.ArtigoUnity.Infraestrutura.EF.DataSource
{
    /// <summary>
    /// Summary description for TesteContextoDb
    /// </summary>
    [TestClass]
    public class TesteContextoDb: InfraDeTeste
    {

        private TestContext testContextInstance;        

        public TesteContextoDb()
        {
            
        }        

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
        [Description("Verifica se os Mapeamentos estão corretos e se o DBContext está sendo corretamente injetado")]
        [TestCategory("ContextDb - Teste de Integração")]
        public void TesteIntegracao()
        {
            ContextoDb contexto = container.Resolve<ContextoDb>();

            Assert.IsInstanceOfType(contexto, typeof(DbContext));
        }        
    }
}
