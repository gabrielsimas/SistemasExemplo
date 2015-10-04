using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Repositorio.Interfaces;
using ArtigoUnity.Infraestrutura.EF.ContextoBD;
using ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao;
using Microsoft.Practices.Unity;

namespace ArtigoUnity.Infraestrutura.IoC.MicrosoftUnity
{
    public static class ContainerDoUnity
    {

        #region Atributos
        static IUnityContainer container;
        #endregion

        #region Construtores
        static ContainerDoUnity()
        {
            CriaContainer();
        }
        #endregion

        #region Propriedades
        public static IUnityContainer Container
        {
            get
            {
                return container;
            }
        }
        #endregion

        #region Injeção de Dependências
        static void CriaContainer()
        {
            container = new UnityContainer();

            //Repositorios
            container.RegisterType<DbContext, ContextoDb>(new HierarchicalLifetimeManager());
            container.RegisterType<IEditoraRepositorio, EditoraRepositorio>(new InjectionConstructor(container.Resolve<ContextoDb>()));
            container.RegisterType<ILivroRepositorio, LivroRepositorio>(new InjectionConstructor(container.Resolve<ContextoDb>()));
        }

        public static IUnityContainer GetContainer()
        {            
            CriaContainer();
            return container;           
        }

        #endregion

    }
}
