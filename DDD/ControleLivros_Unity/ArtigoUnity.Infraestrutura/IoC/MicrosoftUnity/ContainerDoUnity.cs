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
            //CriaContainer();
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
            container.RegisterType<DbContext, ContextoDb>(new HierarchicalLifetimeManager());
            container.RegisterType<IEditoraRepositorio, EditoraRepositorio>(new InjectionConstructor(container.Resolve<ContextoDb>()));
            container.RegisterType<ILivroRepositorio, LivroRepositorio>(new InjectionConstructor(container.Resolve<ContextoDb>()));

            //Servicos de Domínio
            container.RegisterType<ILivroServico, LivroServico>(new InjectionConstructor(container.Resolve<ILivroRepositorio>(), container.Resolve<IEditoraRepositorio>()));
            container.RegisterType<IEditoraServico, EditoraServico>(new InjectionConstructor(container.Resolve<IEditoraRepositorio>()));

            //Aplicação            
            container.RegisterType<ILivroAplicServico, LivroAplicServico>(new InjectionConstructor(container.Resolve<ILivroServico>(), container.Resolve<IEditoraServico>()));
            container.RegisterType<IEditoraAplicServico, EditoraAplicServico>();
            

        }

        public static void InicializaContainer(IUnityContainer containerInjetado)
        {            
                CriaContainer(containerInjetado);         
        }        

        #endregion

    }
}
