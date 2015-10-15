using MVCAngularJS.Entidade;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao
{
    public class CategoriaRepositorio: RepositorioMestre<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(IUnitOfWork unidadeDeTrabalho)
            :base(unidadeDeTrabalho)
        {

        }
    }
}
