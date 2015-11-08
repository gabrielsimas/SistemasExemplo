using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servico.Comum
{
    public interface IServicoDominioPai<T>: IDisposable
        where T: class
    {
        void Cadastrar(T entidade);
        void Alterar(T entidade);
        void Apagar(T entidade);
        ICollection<T> ListarTudo();
    }
}
