using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.Autenticacao;
using DAL.Entidades;
using DAL.Persistencia;

namespace Apresentacao
{
    public partial class Default : System.Web.UI.Page
    {        
        #region Agentes Externos

        private NegocioAutenticacao negocio;
        private UsuarioDao dao;

        #endregion

        #region Atributos de Página
        #endregion

        #region Data Binds
        #endregion

        #region Ações do Usuário
        protected void AutenticarUsuario(object sender, EventArgs e)
        {
            Usuario usuario;

            if (String.IsNullOrEmpty(txtLogin.Text) || String.IsNullOrEmpty(txtSenha.Text))
            {
                lblmensagem.Text = "É necessário que se entre um usuário e senha válidos.";
            }

            using(negocio = new NegocioAutenticacao())
            {
                usuario = new Usuario()
                {
                    Login = txtLogin.Text,
                    Senha = txtSenha.Text
                };

                if (negocio.AutenticarUsuario(usuario))
                {                    
                    using(dao = new UsuarioDao())
                    {
                        Session["Usuario"] = dao.BuscarLogin(usuario.Login).Id.ToString();
                    }

                    Response.Redirect(@"Tarefas\PainelDeTarefas.aspx");
                }
                else
                {
                    lblmensagem.Text = "Usuário ou Senha inválidos. Tente novamente!";
                }
            }
        }
        #endregion        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}