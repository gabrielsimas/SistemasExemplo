using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Servico.Fachada;
using Aplicacao.Servico.Implementacao;
using Dominio.Contrato;
using Dominio.Servico.Implementacao;
using Dominio.Servico.Interfaces;
using Infraestrutura.ORM.EF.Repositorio.Implementacao;
using Microsoft.Practices.Unity;
using Teste.RefactDDD.Comum.EntityFrameworkThings;
using Teste.RefactDDD.Comum.EntityFrameworkThings.Teste;

namespace Teste.RefactDDD.Comum.IoC.MicrosoftUnity
{
    public class ContainerDoUnityParaTeste
    {
        #region Atributos
        static IUnityContainer container;
        #endregion

        #region Construtores
        static ContainerDoUnityParaTeste()
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
            container.RegisterType<DbContext, DbContextParaTeste>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(new InjectionConstructor(container.Resolve<DbContextParaTeste>()));
            container.RegisterType<ITarefaRepositorio, TarefaRepositorio>(new InjectionConstructor(container.Resolve<DbContextParaTeste>()));

            //Servicos de Domínio
            container.RegisterType<IUsuarioServicoDominio, UsuarioServicoDominio>(new InjectionConstructor(container.Resolve<IUsuarioRepositorio>()));
            container.RegisterType<ITarefaServicoDominio, TarefaServicoDominio>(new InjectionConstructor(container.Resolve<ITarefaRepositorio>()));

            //Aplicação
            
            container.RegisterType<IUsuarioAplicServico, UsuarioAplicServico>(new InjectionConstructor(container.Resolve<IUsuarioServicoDominio>()));
            container.RegisterType<ITarefaAplicServico, TarefaAplicServico>(new InjectionConstructor(container.Resolve<ITarefaServicoDominio>()));

            //Testes
            //container.RegisterType(typeof(TesteComTransacao), new InjectionConstructor(container.Resolve<DbContextParaTeste>()));
            
        }

        public static void InicializaContainer(IUnityContainer containerInjetado)
        {
            CriaContainer(containerInjetado);
        }

        #endregion
    }
}
