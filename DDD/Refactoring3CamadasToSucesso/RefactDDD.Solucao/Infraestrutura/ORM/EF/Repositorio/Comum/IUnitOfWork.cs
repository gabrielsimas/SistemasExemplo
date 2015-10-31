using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.ORM.EF.Repositorio.Comum
{
    public interface IUnitOfWork
    {
        void CommitAlteracoes();
        void CommitaERefresha();
        void DesfazAlteracoes();
    }
}
