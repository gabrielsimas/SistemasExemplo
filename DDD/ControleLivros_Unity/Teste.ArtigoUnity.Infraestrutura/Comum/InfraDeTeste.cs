using System;
using ArtigoUnity.Infraestrutura.IoC.MicrosoftUnity;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Teste.ArtigoUnity.Infraestrutura.Comum
{
    [TestClass]
    public class InfraDeTeste
    {
        #region Atributos
        protected IUnityContainer container;
        #endregion

        #region Propriedades
        public IUnityContainer Container
        {
            get
            {
                return this.container;
            }

            private set
            {
                this.container = value;
            }
        }
        #endregion

        #region Testes Unitários
        #endregion

        [TestInitialize]
        public void AbrindoAFirma()
        {
            if (container == null) container = new UnityContainer();
            ContainerDoUnity.InicializaContainer(container);
        }

        [TestCleanup]
        public void LimparGeral()
        {
            foreach (ContainerRegistration item in container.Registrations)
            {
                if (item.RegisteredType.FullName != "Microsoft.Practices.Unity.IUnityContainer")
                {
                    Type objeto = Type.GetType(String.Format("{0},{1}", item.RegisteredType.FullName, item.RegisteredType.Assembly));
                    container.Teardown(objeto);
                }
            }

            container.Dispose();
        }
    }
}
