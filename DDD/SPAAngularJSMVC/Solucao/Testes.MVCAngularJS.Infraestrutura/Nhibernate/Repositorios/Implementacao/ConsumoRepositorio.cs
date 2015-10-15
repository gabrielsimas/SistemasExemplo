using MVCAngularJS.Entidade;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao
{
    public class ConsumoRepositorio: RepositorioMestre<Consumo>, IConsumoRepositorio
    {
        public ConsumoRepositorio(IUnitOfWork unidadeDeTrabalho)
            :base(unidadeDeTrabalho)
        {

        }
    }
}
