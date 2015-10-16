using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MVCAngularJS.Aplicacao.Fachada;
using MVCAngularJS.Aplicacao.Implementacao;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Dominio.Contrato.Servico;
using MVCAngularJS.Dominio.Servico;
using MVCAngularJS.Infraestrutura.Orm.Nhibernate.Configuracao;
using MVCAngularJS.Infraestrutura.Orm.Nhibernate.Repositorios.Implementacao;

namespace MVCAngularJS.Infraestrutura.IoC.Unity
{
    public class UnityResolvedorDeDependencias
    {
        #region Atributos
        static IUnityContainer container;
        #endregion

        #region Construtores
        static UnityResolvedorDeDependencias()
        {

        }
        
        #endregion

        #region Propriedades
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }

            set
            {
                container = value;
            }
        }
        #endregion

        #region Injeção de Dependências
        static void CriaContainer(IUnityContainer container)
        {        
            
            //Repositorios

            container.RegisterType<IUnitOfWork, NhibernateUtil>(new HierarchicalLifetimeManager());
            container.RegisterType<IUnidadeRepositorio, UnidadeRepositorio>(new InjectionConstructor(container.Resolve<IUnitOfWork>()));
            container.RegisterType<IConsumoRepositorio, ConsumoRepositorio>(new InjectionConstructor(container.Resolve<IUnitOfWork>()));
            container.RegisterType<ICategoriaRepositorio, CategoriaRepositorio>(new InjectionConstructor(container.Resolve<IUnitOfWork>()));
            
            //Servicos de Domínio

            container.RegisterType<ICategoriaServico, CategoriaServico>(new InjectionConstructor(container.Resolve<ICategoriaRepositorio>()));
            container.RegisterType<IUnidadeServico, UnidadeServico>(new InjectionConstructor(container.Resolve<IUnidadeRepositorio>()));
            container.RegisterType<IConsumoServico, ConsumoServico>(new InjectionConstructor(container.Resolve<IConsumoRepositorio>()));

            // Aplicação
            container.RegisterType<ICategoriaApp, CategoriaAppServico>(new InjectionConstructor(container.Resolve<ICategoriaServico>()));
            container.RegisterType<IUnidadeApp, UnidadeAppServico>(new InjectionConstructor(container.Resolve<IUnidadeServico>()));
            container.RegisterType<IConsumoApp, ConsumoAppServico>(new InjectionConstructor(container.Resolve<IConsumoServico>()));

        }

        public static void InicializaContainer(IUnityContainer containerInjetado)
        {            
                CriaContainer(containerInjetado);         
        }        

        #endregion

    }
}
