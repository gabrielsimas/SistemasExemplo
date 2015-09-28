using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos;
using Framework.Arquitetura.DDD.Dominio.Interfaces.ServicosDeDominio;

namespace Dominio.Implementacao.Servico
{
    public class TipoTelefoneServico: IServicoDeDominioBase<TipoTelefone>, ITipoTelefoneServico
    {
        #region Atributos
        private ITipoTelefoneRepositorio tipoTelefoneRepositorio;
        #endregion

        #region Construtor
        public TipoTelefoneServico(ITipoTelefoneRepositorio repositorio)
        {
            this.tipoTelefoneRepositorio = repositorio;
        }
        #endregion
    }
}
