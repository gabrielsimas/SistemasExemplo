using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entidades;
using DAL.Persistencia;

namespace BLL.Autenticacao
{
    public class NegocioAutenticacao: IDisposable
    {
        #region Atributos
        private UsuarioDao dao;
        #endregion

        #region Métodos de Negócio
        public Boolean AutenticarUsuario(Usuario usuario)
        {
            using(dao = new UsuarioDao())
            {
                String hash = dao.GeraHashMd5(usuario.Senha);
                Usuario usuarioBanco = dao.BuscarLogin(usuario.Login);

                if (String.IsNullOrEmpty(usuarioBanco.Login))
                {
                    return false;
                }
                else
                {
                    return (usuario.Login.Equals(usuarioBanco.Login) && hash.Equals(usuarioBanco.Senha));
                }                             
            }            
        }

        public Boolean CadastrarNovoUsuario(Usuario usuario)
        {
            using(dao = new UsuarioDao())
            {
                try
                {
                    dao.Gravar(usuario);

                    return true;
                }
                catch (Exception)
                {
                    
                    throw;
                }                
            }            
        }

        #endregion
        public void Dispose()
        {
            dao.Dispose();
        }
    }
}
