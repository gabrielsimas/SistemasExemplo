using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Dominio.Contrato.Servico
{
    public interface IServicoMestre<T>
        where T: class               
    {
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Excluir(T entidade);
        T BuscarPorId(int id);
        ICollection<T> BuscarTodos();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
