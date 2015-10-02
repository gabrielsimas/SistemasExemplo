using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Servico.Interfaces.Base
{
    public interface IBaseServicoFiltrarPor<T>
    {
        T FiltrarUmPor(Func<T, Boolean> lambda);
        ICollection<T> FiltrarVariosPor(Func<T, Boolean> lambda);
    }
}
