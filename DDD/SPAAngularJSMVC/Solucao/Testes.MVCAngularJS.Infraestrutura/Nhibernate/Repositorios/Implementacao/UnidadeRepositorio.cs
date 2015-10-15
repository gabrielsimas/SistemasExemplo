using MVCAngularJS.Entidade;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao;
using Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces;


namespace Teste.MVCAngularJS.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Implementacao
{
    public class UnidadeRepositorio: RepositorioMestre<Unidade>, IUnidadeRepositorio
    {
        public UnidadeRepositorio(IUnitOfWork baseDeTrabalho)
            :base(baseDeTrabalho)
        {

        }
    }
}
