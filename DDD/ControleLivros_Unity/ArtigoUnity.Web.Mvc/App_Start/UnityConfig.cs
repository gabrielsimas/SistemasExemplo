using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Aplicacao.Servico.Fachada;
using ArtigoUnity.Aplicacao.Servico.Implementacao;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Dominio.Servico.Implementacao;
using ArtigoUnity.Dominio.Servico.Interfaces;
using ArtigoUnity.Infraestrutura.EF.ContextoBD;
using ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao;
using ArtigoUnity.Infraestrutura.IoC.MicrosoftUnity;
using Microsoft.Practices.Unity;

namespace ArtigoUnity.Web.Mvc.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
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
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            ContainerDoUnity.InicializaContainer(container);            
        }
    }
}
