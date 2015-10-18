using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Dominio.Contrato.Repositorio
{
    public interface IRepositorioMestre<T>
        where T: class
    {        
        void Salvar(T entidade);        
        void Alterar(T entidade);        
        void Excluir(T entidade);        
        ICollection<T> BuscarTodos();
        T BuscarPorId(int id);
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
