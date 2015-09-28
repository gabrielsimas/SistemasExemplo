using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;

namespace Dominio.Implementacao.Servico
{
    public class RedeSocialServico: ServicoDeDominioBase<RedeSocial>,IRedeSocialServico
    {
        #region Atributos

        private IRedeSocialRepositorio redeSocialRepositorio;

        #endregion

        #region Construtores

        public RedeSocialServico(IRedeSocialRepositorio repositorio)
            :base(repositorio)
        {
            this.redeSocialRepositorio = repositorio;
        }

        #endregion
    }
}
