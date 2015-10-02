using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Dominio.Servico.Interfaces.Base
{
    public interface IBaseServicoAlterar<T>
        where T: class
    {
        void Alterar(T entidade);
    }
}
