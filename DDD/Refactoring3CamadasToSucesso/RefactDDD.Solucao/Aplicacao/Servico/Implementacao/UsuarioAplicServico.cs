using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Dominio.Entidade;
using Dominio.Servico.Interfaces;
using Aplicacao.Montador;
using AutoMapper;
using Aplicacao.Mappers;

namespace Aplicacao.Servico.Implementacao
{
    public class UsuarioAplicServico: IUsuarioAplicServico
    {
        #region Atributos

        private IUsuarioServicoDominio dominio;
        private IMapper mapper;

        #endregion

        #region Construtores
        public UsuarioAplicServico(IUsuarioServicoDominio dominio)
        {
            this.dominio = dominio;
            this.mapper = AutoMapperConfigFactory.GetMapper();
        }

        #endregion

        #region Métodos do Serviço de Aplicação
        public bool AutenticarUsuario(UsuarioDto usuario)
        {                        
            return dominio.AutenticarUsuario(mapper.Map<Usuario>(usuario));
        }

        public void CadastrarNovoUsuario(UsuarioDto usuario)
        {
            //Usuario usuarioDom = Montador.Montador.Monta(usuario);
            dominio.CadastrarNovoUsuario(mapper.Map<Usuario>(usuario));
            dominio.CommitAlteracoes();
        }
        public UsuarioDto BuscarUsuarioPorLogin(UsuarioDto usuario)
        {
            //Usuario usuarioDom = Montador.Montador.Monta(usuario);
            Usuario resultado = dominio.BuscarUsuarioPorLogin(mapper.Map<Usuario>(usuario));

            if(resultado != null)
            {
                return Montador.Montador.Monta(resultado);
            }
            else
            {
                return null;
            }            
        }
        #endregion                    
    }
}
