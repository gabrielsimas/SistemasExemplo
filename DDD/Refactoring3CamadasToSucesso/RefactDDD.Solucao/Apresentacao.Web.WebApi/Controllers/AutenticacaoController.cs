using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Swashbuckle.Swagger.Annotations;

namespace Apresentacao.Web.WebApi.Controllers
{
    [EnableCors(origins: "http://localhost", headers: "*", methods: "get,post")]
    [AllowAnonymous]
    [RoutePrefix("v1/usuario")]
    public class AutenticacaoController : ApiController
    {

        #region Atributos

        private IUsuarioAplicServico usuarioAplicacaoServico;

        #endregion

        #region Construtores

        public AutenticacaoController(IUsuarioAplicServico usuarioAplicServico)
        {
            this.usuarioAplicacaoServico = usuarioAplicServico;
        }

        #endregion
        
        #region Métodos da API

        /// <summary>
        /// Autentica o Usuário.
        /// </summary>
        /// <param name="usuario">Objeto contendo o login e a senha do Usuário.</param>
        /// <returns>200 para sucesso ou 403 para falha</returns>
        [HttpPost]        
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(UsuarioDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]        
        [Route("autenticar")]
        public HttpResponseMessage AutenticarUsuario(UsuarioDto usuario)
        {
            try
            {
                if (usuarioAplicacaoServico.AutenticarUsuario(usuario))
                {                    
                    return Request.CreateResponse(HttpStatusCode.OK, usuario);
                }
                else
                {
                   return Request.CreateResponse(HttpStatusCode.Forbidden);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);                
            }
        }
        
        /// <summary>
        /// Cadastra um novo Usuário para acesso ao Sistema.
        /// </summary>
        /// <param name="usuario">objeto contendo os dados do Usuário a ser cadastrado</param>
        /// <returns>200 para sucesso ou 403 para falha</returns>
        [HttpPost]        
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(UsuarioDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]        
        [Route("")]
        public HttpResponseMessage CadastrarNovoUsuario(UsuarioDto usuario)
        {
            try
            {
                usuarioAplicacaoServico.CadastrarNovoUsuario(usuario);

                return Request.CreateResponse(HttpStatusCode.OK,usuario);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        /// <summary>
        /// Procura um usuário por seu Login previamente cadastrado
        /// </summary>
        /// <param name="login">O login do usuário que se quer buscar</param>
        /// <returns>200 para sucesso ou 403 para falha</returns>
        [HttpGet]        
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(UsuarioDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]        
        [Route("")]
        public HttpResponseMessage BuscarUsuarioPorLogin(string login)
        {
            try
            {
                UsuarioDto dto = new UsuarioDto() { Login = login};
                dto = usuarioAplicacaoServico.BuscarUsuarioPorLogin(dto);

                if (dto.Id.HasValue)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,dto);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        #endregion
        
    }
}
