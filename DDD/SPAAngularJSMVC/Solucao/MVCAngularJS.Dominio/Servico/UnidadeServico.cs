﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Dominio.Contrato.Servico;
using MVCAngularJS.Entidade;

namespace MVCAngularJS.Dominio.Servico
{
    public class UnidadeServico: ServicoMestre<Unidade>, IUnidadeServico
    {
        public UnidadeServico(IUnidadeRepositorio repositorio)
            :base(repositorio)
        {            
        }
    }
}
