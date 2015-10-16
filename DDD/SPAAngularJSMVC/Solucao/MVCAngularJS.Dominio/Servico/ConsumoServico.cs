using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Dominio.Contrato.Servico;
using MVCAngularJS.Entidade;

namespace MVCAngularJS.Dominio.Servico
{
    public class ConsumoServico:ServicoMestre<Consumo>, IConsumoServico
    {
        public ConsumoServico(IConsumoRepositorio repositorio)
            :base(repositorio)
        {

        }
    }
}
