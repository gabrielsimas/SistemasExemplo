using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MVCAngularJS.Dominio.Contrato.Servico;
using MVCAngularJS.Dominio.Servico;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.FluentApi.Configuracao;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;
using Teste.MVCAngularJS.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao;

namespace Teste.MVCAngularJS.Infraestrutura.IoC.Unity
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
            /*
            container.RegisterType<ILivroServico, LivroServico>(new InjectionConstructor(container.Resolve<ILivroRepositorio>(), container.Resolve<IEditoraRepositorio>()));
            container.RegisterType<IEditoraServico, EditoraServico>(new InjectionConstructor(container.Resolve<IEditoraRepositorio>()));
            */
            //Aplicação            
            /*
            container.RegisterType<ILivroAplicServico, LivroAplicServico>(new InjectionConstructor(container.Resolve<ILivroServico>(), container.Resolve<IEditoraServico>()));
            container.RegisterType<IEditoraAplicServico, EditoraAplicServico>();
             */           
        }

        public static void InicializaContainer(IUnityContainer containerInjetado)
        {            
                CriaContainer(containerInjetado);         
        }        

        #endregion

    }
}
