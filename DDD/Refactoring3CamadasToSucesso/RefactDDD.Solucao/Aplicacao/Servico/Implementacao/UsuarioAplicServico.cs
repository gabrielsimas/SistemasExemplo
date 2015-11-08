using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Dominio.Entidade;
using Dominio.Servico.Interfaces;

namespace Aplicacao.Servico.Implementacao
{
    public class UsuarioAplicServico: IUsuarioAplicServico
    {
        #region Atributos

        private IUsuarioServicoDominio dominio;

        #endregion

        #region Construtores
        public UsuarioAplicServico(IUsuarioServicoDominio dominio)
        {
            this.dominio = dominio;
        }

        #endregion

        #region Métodos do Serviço de Aplicação
        public bool AutenticarUsuario(UsuarioDto usuario)
        {
            Usuario usuarioDom = new Usuario();
            Montador.Montador.Monta(usuario, usuarioDom);
            return dominio.AutenticarUsuario(usuarioDom);
        }

        public void CadastrarNovoUsuario(UsuarioDto usuario)
        {
            Usuario usuarioDom = new Usuario();
            Montador.Montador.Monta(usuario, usuarioDom);
            dominio.CadastrarNovoUsuario(usuarioDom);
            dominio.CommitAlteracoes();
        }

        #endregion        
    }
}
