using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Contrato;
using Dominio.Entidade;
using Dominio.Servico.Comum;
using Dominio.Servico.Interfaces;
using Framework.Utils.Seguranca;
using Infraestrutura.ORM.EF.Repositorio.Comum;

namespace Dominio.Servico.Implementacao
{
    public class UsuarioServicoDominio: IUsuarioServicoDominio, IUnitOfWork
    {
        #region Atributos

        private IUsuarioRepositorio repositorio;

        #endregion

        #region Construtor
        public UsuarioServicoDominio(IUsuarioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        #endregion

        #region Métodos de Serviço do Dominio

        public bool AutenticarUsuario(Usuario usuario)
        {
            //Localiza o usuário pelo Login
            Usuario usuarioR = repositorio.FiltrarSimplesPor(u => u.Login.Equals(usuario.Login));
            return usuarioR.Login.Equals(usuarioR.Login) && Cerberus.ValidaSenha(usuario.Senha,"SHA3",null);
        }

        public void CadastrarNovoUsuario(Usuario usuario)
        {
            usuario.Senha = Cerberus.GeraValorHash(usuario.Senha,"SHA3",null);
            repositorio.Criar(usuario);
        }

        public void CommitAlteracoes()
        {
            repositorio.CommitAlteracoes();
        }

        public void CommitaERefresha()
        {
            repositorio.CommitaERefresha();
        }

        public void DesfazAlteracoes()
        {
            repositorio.DesfazAlteracoes();
        }

        public void Dispose()
        {

        }

        #endregion                             
    }
}
