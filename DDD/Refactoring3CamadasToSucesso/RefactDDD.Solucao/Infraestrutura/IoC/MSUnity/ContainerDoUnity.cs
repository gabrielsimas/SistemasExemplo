using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Mappers;
using Aplicacao.Servico.Fachada;
using Aplicacao.Servico.Implementacao;
using AutoMapper;
using Dominio.Contrato;
using Dominio.Servico.Implementacao;
using Dominio.Servico.Interfaces;
using Infraestrutura.ORM.EF.ContextoDB;
using Infraestrutura.ORM.EF.Repositorio.Implementacao;
using Microsoft.Practices.Unity;

namespace Infraestrutura.IoC.MSUnity
{
    public class ContainerDoUnity
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
            container.RegisterType<DbContext, Conexao>(new HierarchicalLifetimeManager());
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(new InjectionConstructor(container.Resolve<Conexao>()));
            container.RegisterType<ITarefaRepositorio, TarefaRepositorio>(new InjectionConstructor(container.Resolve<Conexao>()));
            

            //Servicos de Domínio
            container.RegisterType<IUsuarioServicoDominio, UsuarioServicoDominio>(new InjectionConstructor(container.Resolve<IUsuarioRepositorio>()));
            container.RegisterType<ITarefaServicoDominio, TarefaServicoDominio>(new InjectionConstructor(container.Resolve<ITarefaRepositorio>()));

            //Aplicação            
            container.RegisterType<IUsuarioAplicServico, UsuarioAplicServico>(new InjectionConstructor(container.Resolve<IUsuarioServicoDominio>()));
            container.RegisterType<ITarefaAplicServico, TarefaAplicServico>(new InjectionConstructor(container.Resolve<ITarefaServicoDominio>()));            
        }

        public static void InicializaContainer(IUnityContainer containerInjetado)
        {
            CriaContainer(containerInjetado);
        }

        #endregion

    }
}
