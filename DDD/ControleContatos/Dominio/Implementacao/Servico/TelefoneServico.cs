﻿using System;
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
    public class TelefoneServico: ServicoDeDominioBase<Telefone>, ITelefoneServico
    {
        #region Atributos

        private ITelefoneRepositorio telefoneRepositorio;

        #endregion

        #region Construtores
        public TelefoneServico(ITelefoneRepositorio repositorio)
            :base(repositorio)
        {
            this.telefoneRepositorio = repositorio;
        }
        #endregion
    }
}
