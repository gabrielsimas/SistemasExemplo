using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Aplicacao.Dto;
using MVCAngularJS.Aplicacao.Fachada;
using MVCAngularJS.Dominio.Contrato.Servico;
using MVCAngularJS.Entidade;

namespace MVCAngularJS.Aplicacao.Implementacao
{
    public class ConsumoAppServico: AppServicoMestre<Consumo,ConsumoDto>, IConsumoApp
    {
        public ConsumoAppServico(IServicoMestre<Consumo> servico)
            :base(servico)
        {

        }
    }
}
