using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ddd.Dominio.Modelo.Comum.ValueObject;

namespace Teste.Ddd.Dominio.Modelo.VOs
{
    /// <summary>
    /// Summary description for CpfTeste
    /// </summary>
    [TestClass]
    public class CpfTeste
    {
        public static readonly String[] CpfsValidos = {"18530249100","297.276.931-72" ,"29727693172" ,  "046.428.359-03" , "04642835903" ,  "023.750.169-47" ,  "02375016947" ,  "855.826.525-90" ,  "669.712.265-00" ,  "01646227212" ,  "96183390259" ,  "63118670282" ,"57212970263","85272175204" ,  "84250739287" ,  "74390651234" , "93582803287" ,  "84569190200" ,  "51914794249" ,  "67681530215" ,  "51918102287" ,  "59925272220" ,	 "72178507204" ,  "85542520200" ,  "98089242200" ,  "66100313200" ,  "51405300230" ,  "13187110703" };

        public static readonly String[] CpfsInvalidos = { "005.333.839-18", "00533383910", "030.405.039-35", "03040503934", "046.428.359-02", "04642835913", "023.750.169-57", "02375016937", "855.826.525-91", "669.712.265-10", "01646227211", "96183390269", "63118670283", "57212970273", "85272175206", "84250739284", "74390651233", "93582803297", "84569190201", "51914794259", "67681530214", "51918102282", "59925272221", "72178507294", "85542520210", "98089242210", "66100313201", "51405300238", "13187110704" };

        public static readonly String[] NumerosRepetidos = { "00000000000", "11111111111", "22222222222", "33333333333", "44444444444", "55555555555", "66666666666", "77777777777", "88888888888", "99999999999" };

        public CpfTeste()
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
        public void TestaOsCpfsValidos()
        {
            foreach(String cpf in CpfsValidos)
            {                
                Assert.IsTrue(Cpf.ValidaCpf(cpf));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestaOsCpfsInvalidos()
        {
            foreach (String cpf in CpfsInvalidos)
            {
                Assert.IsFalse(Cpf.ValidaCpf(cpf));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestaOsCpfsComNumerosRepetidos()
        {
            foreach (String cpf in NumerosRepetidos)
            {
                Cpf.ValidaCpf(cpf);
            }
        }
    }
}
