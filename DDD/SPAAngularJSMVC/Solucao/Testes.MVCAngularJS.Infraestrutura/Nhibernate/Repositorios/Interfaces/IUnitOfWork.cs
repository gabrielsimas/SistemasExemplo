using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste.MVCAngularJS.Infraestrutura.Nhibernate.Repositorios.Interfaces
{
    public interface IUnitOfWork
    {
        void IniciarTransacao();
        void GravaAlteracoesNoBanco();
    }
}
