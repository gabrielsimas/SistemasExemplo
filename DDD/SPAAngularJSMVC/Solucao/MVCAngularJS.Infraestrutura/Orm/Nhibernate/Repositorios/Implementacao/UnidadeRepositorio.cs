using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Entidade;

namespace MVCAngularJS.Infraestrutura.Orm.Nhibernate.Repositorios.Implementacao
{
    public class UnidadeRepositorio: RepositorioMestre<Unidade>, IUnidadeRepositorio
    {
        public UnidadeRepositorio(IUnitOfWork baseDeTrabalho)
            :base(baseDeTrabalho)
        {

        }
    }
}
