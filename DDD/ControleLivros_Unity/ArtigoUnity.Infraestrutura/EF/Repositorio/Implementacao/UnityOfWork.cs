using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtigoUnity.Dominio.Repositorio.Interfaces.Base;

namespace ArtigoUnity.Infraestrutura.EF.Repositorio.Implementacao
{
    public class UnityOfWork: IUnitOfWork
    {
        public void CommitAlteracoes()
        {
            throw new NotImplementedException();
        }

        public void CommitaERefresha()
        {
            throw new NotImplementedException();
        }

        public void DesfazAlteracoes()
        {
            throw new NotImplementedException();
        }
    }
}
