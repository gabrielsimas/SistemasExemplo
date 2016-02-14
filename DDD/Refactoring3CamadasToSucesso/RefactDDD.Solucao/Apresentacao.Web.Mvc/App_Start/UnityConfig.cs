using System;
using Infraestrutura.IoC.MSUnity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Apresentacao.Web.Mvc.App_Start
{
    /// <summary>
    /// Especifica a configuração do Unity para o container principal.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Pega o container do Unity já configurado.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion
        
       /// <summary>
       /// Inicializa o Container existente na Camada de infraestrutura
       /// </summary>
       /// <param name="container">objeto do tipo IUnityContainer instanciado com o container</param>
        public static void RegisterTypes(IUnityContainer container)
        {
            ContainerDoUnity.InicializaContainer(container);
        }
    }
}
