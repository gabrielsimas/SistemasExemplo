using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.ServicosDominio;
using Framework.Arquitetura.DDD.Aplicacao.Implementacao;
using Framework.Arquitetura.DDD.Dominio.Implementacao.ServicosDeDominio.EF;



namespace Dominio.Implementacao.Servico
{
    public class AutorDominioServico: ServicoDeDominioBase<Autor>, IServicoDominioAutor
    {
        #region Atributos
        private IAutorRepositorio autorRepositorio;
        #endregion

        #region Construtores
        public AutorDominioServico(IAutorRepositorio autorRepositorio)
            :base(autorRepositorio)
        {
            this.autorRepositorio = autorRepositorio;
        }
        #endregion

        #region Métodos de Serviço de Dominio

        #endregion
    }
}
