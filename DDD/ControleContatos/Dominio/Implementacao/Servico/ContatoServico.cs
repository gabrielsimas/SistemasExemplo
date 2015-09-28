using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;

namespace Dominio.Implementacao.Servico
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
