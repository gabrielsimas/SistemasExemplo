using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Swashbuckle.Swagger.Annotations;


namespace Apresentacao.Web.WebApi.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"get,post,put,patch,delete")]
    [AllowAnonymous]
    [RoutePrefix("v1/tarefa")]
    public class TarefaController : ApiController
    {
        #region Atributos

        private ITarefaAplicServico tarefaAplicacaoServico;

        #endregion

        #region Construtores
        public TarefaController(ITarefaAplicServico tarefaAplicacaoServico)
        {
            this.tarefaAplicacaoServico = tarefaAplicacaoServico;
        }

        #endregion

        #region Métodos da API

        /// <summary>
        /// Cadastra uma Tarefa Nova
        /// </summary>
        /// <param name="tarefa">Objeto contendo a Tarefa</param>
        /// <returns>200 para sucesso ou 403 para falha</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.OK,Type=typeof(TarefaDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]        
        [Route("")]
        public HttpResponseMessage CadastrarTarefa(TarefaDto tarefa)
        {
            try
            {                
                tarefaAplicacaoServico.CadastrarTarefa(tarefa);

                return Request.CreateResponse(HttpStatusCode.OK, tarefa);
            }
            catch(Exception ex)
            {
               return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

        /// <summary>
        /// Altera uma tarefa já cadastrada!
        /// </summary>
        /// <param name="tarefa">Objeto tarefa com o Id da Tarefa preenchido.</param>
        /// <returns>200 para sucesso e 403 para falha</returns>
        [HttpPut]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(TarefaDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]
        [Route("")]
        public HttpResponseMessage AlterarTarefa(TarefaDto tarefa)
        {
            try
            {
                tarefaAplicacaoServico.AlterarTarefa(tarefa);

                return Request.CreateResponse(HttpStatusCode.OK, tarefa);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }

        }

        /// <summary>
        /// Excluir uma tarefa selecionada
        /// </summary>
        /// <param name="tarefa">objeto contendo o Id da tarefa prenchido
        /// pois é aqui que ele irá identificar a tarefa</param>
        /// <returns>200 para sucesso e 403 para falha</returns>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(TarefaDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]
        [Route("")]
        public HttpResponseMessage ApagarTarefa(TarefaDto tarefa)
        {
            try
            {
                tarefaAplicacaoServico.ApagarTarefa(tarefa);
                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa excluída com sucesso!");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

        /// <summary>
        /// Marca uma tarefa em aberto como concluída
        /// </summary>
        /// <param name="tarefa">Objeto Tarefa cotendo o Id da tarefa que se deseja macar como 'Executada'</param>
        /// <returns>200 para sucesso e 403 para falha</returns>
        [HttpPatch]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(TarefaDto))]
        [SwaggerResponse(HttpStatusCode.Forbidden, Type = typeof(Exception))]
        [Route("")]
        public HttpResponseMessage MarcarTarefaComoConcluida(TarefaDto tarefa)
        {
            try
            {
                tarefaAplicacaoServico.MarcarTarefaComoConcluida(tarefa);
                return Request.CreateResponse(HttpStatusCode.OK, "Tarefa executada!");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

        /// <summary>
        /// Lista todas as Tarefas baseadas em um tipo de busca
        /// </summary>
        /// <param name="idUsuario">Id do Usuário</param>
        /// <param name="tipoBusca">
        /// Tipo de Busca
        /// 0 => Todas as tarefas
        /// 1 => Tarefas à vencer
        /// 2 => Tarefas concluídas
        /// 3 => ListarTarefasAtrasadas      
        /// 4 => Por Range de datas
        /// </param>
        /// <param name="dataInicio">Data de Início do Filtro de datas</param>
        /// <param name="dataTermino">Data de Término do Filtro de datas></param>
        /// <returns>200 para sucesso e 403 para falha</returns>        
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ICollection<TarefaDto>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(Exception))]
        [Route("")]
        public HttpResponseMessage ListaTarefas(string idUsuario, string tipoBusca, String dataInicio = null, String dataTermino = null)
        {
            try
            {
                ICollection<TarefaDto> tarefas = new List<TarefaDto>();

                TarefaDto dto = new TarefaDto()
                {
                    IdUsuario = long.Parse(idUsuario)
                };

                switch (int.Parse(tipoBusca))
                {
                    case 0:
                        tarefas = tarefaAplicacaoServico.ListarTodasAsTarefasDoUsuario(dto);

                        if (tarefas != null && tarefas.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, tarefas.ToList());
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    case 1:
                        tarefas = tarefaAplicacaoServico.ListarTarefasAVencer(dto);

                        if (tarefas != null && tarefas.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, tarefas.ToList());
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    case 2:
                        tarefas = tarefaAplicacaoServico.ListarTarefasConcluidas(dto);

                        if (tarefas != null && tarefas.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, tarefas.ToList());
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    case 3:

                        tarefas = tarefaAplicacaoServico.ListarTarefasAtrasadas(dto);

                        if (tarefas != null && tarefas.Count > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK, tarefas.ToList());
                        }
                        else
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    default:
                        return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

        #endregion        
    }
}
