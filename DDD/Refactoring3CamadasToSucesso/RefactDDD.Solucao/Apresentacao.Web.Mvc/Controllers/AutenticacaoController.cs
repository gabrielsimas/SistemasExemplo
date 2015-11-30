using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Apresentacao.Web.Mvc.Excecao;
using Apresentacao.Web.Mvc.Models;
using SwaggerAPIDocumentation;

namespace Apresentacao.Web.Mvc.Controllers
{
	public class AutenticacaoController : Controller
    {
        #region Atributos

        private IUsuarioAplicServico usuarioAplicacaoServico;

        #endregion

        #region Construtores
        public AutenticacaoController(IUsuarioAplicServico usuarioAplicacaoServico)
        {
            this.usuarioAplicacaoServico = usuarioAplicacaoServico;
        }

        #endregion

        #region Actions

        [HttpPost]
        public ActionResult CadastrarUsuario(UsuarioCadastroModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioDto dto = Montador.MontaModeloDominioEViceVersa.Monta(model);

                    usuarioAplicacaoServico.CadastrarNovoUsuario(dto);

                    dto.senha = null;

                    return Json(new { UsuarioModel = Json(dto) }, "application/json");
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;

                    IList<String> erros = new List<String>();
                    foreach (ModelState modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            erros.Add(error.ErrorMessage);
                        }
                    }

                    throw new ExcecaoUsuario(Json(erros, "application/json", Encoding.UTF8).ToString());
                }
            }
            catch (ExcecaoUsuario eu)
            {
                return Json(new { UsuarioExcecao = String.Format("Erro: {0}", eu.Message) }, "application/json", Encoding.UTF8);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return Json(new { UsuarioExcecao = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
            }
        }

        [HttpPost]
        public ActionResult Autenticar(AutenticacaoModel model)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    UsuarioDto dto = Montador.MontaModeloDominioEViceVersa.Monta(model);

                    if (usuarioAplicacaoServico.AutenticarUsuario(dto))
                    {
                        UsuarioDto resultado = usuarioAplicacaoServico.BuscarUsuarioPorLogin(dto);
                        resultado.senha = null;
                        return Json(new { AutenticacaoModel = resultado }, "application/json", Encoding.UTF8);
                    }
                    else
                    {
                        HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                        throw new ExcecaoAutenticacao("Não é possível efetuar o Logon, provável erro de Usuário e Senha. Verifique seus dados!!");
                    }
                }
                else
                {
                    HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                    IList<String> erros = new List<String>();
                    foreach (ModelState modelState in ViewData.ModelState.Values)
                    {
                        foreach (ModelError error in modelState.Errors)
                        {
                            erros.Add(error.ErrorMessage);
                        }
                    }
                    throw new ExcecaoAutenticacao(Json(erros, "application/json", Encoding.UTF8).ToString());
                }
            }
            catch (ExcecaoAutenticacao ea)
            {
                return Json(new { AutenticacaoExcecao = String.Format("Erro: {0}", ea.Message) }, "application/json", Encoding.UTF8);
            }
            catch (Exception ex)
            {

                return Json(new { AutenticacaoExcecao = String.Format("Erro: {0}", ex.Message) });
            }

        }

        #endregion        
	}
}