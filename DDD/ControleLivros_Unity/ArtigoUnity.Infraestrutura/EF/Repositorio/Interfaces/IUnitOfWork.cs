using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtigoUnity.Infraestrutura.EF.Repositorio.Interfaces
{
    public interface IUnitOfWork
    {
        void CommitAlteracoes();

        void CommitaERefresha();

        void DesfazAlteracoes();
    }
}
