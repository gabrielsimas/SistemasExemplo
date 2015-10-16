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
    public class CategoriaServico: ServicoMestre<Categoria>, ICategoriaServico
    {
        public CategoriaServico(ICategoriaRepositorio repositorio)
            :base(repositorio)
        {

        }
    }
}
