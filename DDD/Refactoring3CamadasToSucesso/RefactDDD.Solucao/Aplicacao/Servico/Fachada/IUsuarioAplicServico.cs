using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacao.Dto;

namespace Aplicacao.Servico.Fachada
{
    public interface IUsuarioAplicServico
    {
        bool AutenticarUsuario(UsuarioDto usuario);
        void CadastrarNovoUsuario(UsuarioDto usuario);
    }
}
