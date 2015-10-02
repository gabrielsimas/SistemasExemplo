using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Servico.Interfaces.Base
{
    public interface IBaseServicoListar<T>
        where T: class
    {
        T BuscarPorId(Nullable<long> id);
        ICollection<T> ListarTudo();

    }
}
