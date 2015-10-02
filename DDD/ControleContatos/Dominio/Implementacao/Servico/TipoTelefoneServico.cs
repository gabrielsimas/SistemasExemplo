using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;
using Framework.Arquitetura.DDD.Dominio.Interfaces.ServicosDeDominio;

namespace Dominio.Implementacao.Servico
{
    public class TipoTelefoneServico: ServicoDeDominioBase<TipoTelefone>, ITipoTelefoneServico, IDisposable
    {
        #region Atributos
        private ITipoTelefoneRepositorio tipoTelefoneRepositorio;
        #endregion

        #region Construtor
        public TipoTelefoneServico(ITipoTelefoneRepositorio repositorio)
            :base(repositorio)
        {
            this.tipoTelefoneRepositorio = repositorio;
        }
        #endregion

        
    }
}
