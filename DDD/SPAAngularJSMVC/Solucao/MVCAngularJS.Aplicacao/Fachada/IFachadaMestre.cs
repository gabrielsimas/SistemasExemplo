using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Aplicacao.Fachada
{
   public interface IFachadaMestre<DTO>
    where DTO: class               
    {
        void Cadastrar(DTO dto);
        void Alterar(DTO dto);
        void Excluir(DTO dto);
        DTO BuscarPorId(int id);
        ICollection<DTO> BuscarTodos();
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
