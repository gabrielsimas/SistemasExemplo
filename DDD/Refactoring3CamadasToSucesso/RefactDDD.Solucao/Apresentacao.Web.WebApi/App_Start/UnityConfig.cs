using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using Infraestrutura.IoC.MSUnity;

namespace Apresentacao.Web.WebApi
{
	public static class UnityConfig
	{
		public static void RegisterComponents()
		{
			var container = new UnityContainer();

			ContainerDoUnity.InicializaContainer(container);
			
			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
		}
	}
}