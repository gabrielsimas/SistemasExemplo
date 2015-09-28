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
    public class TipoRedeSocialServico: IServicoDeDominioBase<TipoRedeSocial>, ITipoRedeSocialServico
    {
        #region Atributos

        private ITipoRedeSocialRepositorio tipoRedeSocialRepositorio;

        #endregion

        #region Construtores
        public TipoRedeSocialServico(ITipoRedeSocialRepositorio repositorio)
        {
            this.tipoRedeSocialRepositorio = repositorio;
        }
        #endregion
    }
}
