using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ddd.Dominio.Modelo.Cliente;
using Ddd.Dominio.Modelo.Comum.ValueObject;

namespace Teste.Ddd.Dominio.Modelo
{
    /// <summary>
    /// Summary description for ClienteTeste
    /// </summary>
    [TestClass]
    public class ClienteTeste
    {
        public ClienteTeste()
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

        [TestMethod]
        public void InstanciaCliente()
        {
            Identidade id = Identidade.of(1);
            Nome nome = Nome.of("Luís Gabriel N. Simas");
            Endereco endereco = Endereco.of(Logradouro.of("Rua Ademar Barcelos, 26 - Sobrado"), Cep.of("20211-018"), Cidade.of("Rio de Janeiro"), Estado.of("RJ"));
            Email email = Email.of("autorgabrielsimas@gmail.com");
            Cpf cpf = Cpf.of("06789399690");

            Cliente cliente = Cliente.of(id,nome, endereco, email, cpf);

            Assert.IsTrue(!String.IsNullOrEmpty(cliente.ToString()));
        }
    }
}
