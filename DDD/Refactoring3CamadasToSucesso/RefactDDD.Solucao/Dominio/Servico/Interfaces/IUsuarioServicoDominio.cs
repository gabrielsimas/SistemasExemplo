using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade;
using Dominio.Servico.Comum;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Dominio.Servico.Interfaces
{
    public interface IUsuarioServicoDominio : IUnitOfWork, IDisposable 
    {
        bool AutenticarUsuario(Usuario usuario);
        void CadastrarNovoUsuario(Usuario usuario);
    }
}
