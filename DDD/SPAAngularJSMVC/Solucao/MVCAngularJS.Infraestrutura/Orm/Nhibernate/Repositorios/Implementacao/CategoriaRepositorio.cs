using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCAngularJS.Dominio.Contrato.Repositorio;
using MVCAngularJS.Entidade;


namespace MVCAngularJS.Infraestrutura.Orm.Nhibernate.Repositorios.Implementacao
{
    public class CategoriaRepositorio: RepositorioMestre<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(IUnitOfWork unidadeDeTrabalho)
            :base(unidadeDeTrabalho)
        {

        }
    }
}
