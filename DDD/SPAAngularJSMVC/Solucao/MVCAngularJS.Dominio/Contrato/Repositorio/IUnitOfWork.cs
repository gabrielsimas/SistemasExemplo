using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCAngularJS.Dominio.Contrato.Repositorio
{
    public interface IUnitOfWork
    {
        void IniciarTransacao();
        void GravaAlteracoesNoBanco();
    }
}
