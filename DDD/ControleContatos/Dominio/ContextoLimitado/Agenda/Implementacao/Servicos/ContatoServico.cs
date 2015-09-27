using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.ContextoLimitado.Agenda.Interfaces.Repositorios;
using Dominio.ContextoLimitado.Agenda.Interfaces.Servicos;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;

namespace Dominio.ContextoLimitado.Agenda.Implementacao.Servicos
{
    public class ContatoServico: ServicoDeDominioBase<Contato>, IContatoServico
    {
        #region Atributos

        private IContatoRepositorio contatoRepositorio;

        #endregion

        #region Construtores
        public ContatoServico(IContatoRepositorio repositorio)
            :base(repositorio)
        {
            this.contatoRepositorio = repositorio;
        }
        #endregion
    }
}
