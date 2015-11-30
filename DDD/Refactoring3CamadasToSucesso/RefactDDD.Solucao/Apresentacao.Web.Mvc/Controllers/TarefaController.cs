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

namespace Apresentacao.Web.Mvc.Controllers
{
	public class TarefaController : Controller
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

		#region Actions

		[HttpPost]
		public ActionResult CadastrarTarefa(TarefaCadastroModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					TarefaDto dto = Montador.MontaModeloDominioEViceVersa.Monta(model);

					tarefaAplicacaoServico.CadastrarTarefa(dto);

					return Json(new {TarefaModel = dto},"application/json",Encoding.UTF8);
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

					throw new ExcecaoTarefa(Json(erros,"application/json", Encoding.UTF8).ToString());
				}


			}
			catch(ExcecaoTarefa et)
			{
				return Json(new {ExcecaoTarefa = String.Format("Erro: {0}", et.Message)},"application/json",Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}
		}

		[HttpPut]
		public ActionResult EditarTarefa(TarefaEdicaoModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					TarefaDto dto = Montador.MontaModeloDominioEViceVersa.Monta(model);

					tarefaAplicacaoServico.AlterarTarefa(dto);

					return Json(new { TarefaModel = dto },"application/json",Encoding.UTF8);
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

					throw new ExcecaoTarefa(Json(erros,"application/json",Encoding.UTF8).ToString());
				}
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}
		}

		[HttpDelete]
		public ActionResult ExcluirTarefa(TarefaExcluirModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					TarefaDto dto = Montador.MontaModeloDominioEViceVersa.Monta(model);

					tarefaAplicacaoServico.ApagarTarefa(dto);

					return Json(string.Format("Tarefa {0} excluída com sucesso!", dto.Nome),"application/json",Encoding.UTF8);
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

                    throw new ExcecaoTarefa(Json(erros,"application/json",Encoding.UTF8).ToString());
				}
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}
		}

		[HttpPatch]
		public ActionResult ExecutarTarefa(TarefaEdicaoModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					TarefaDto dto = Montador.MontaModeloDominioEViceVersa.Monta(model);
					tarefaAplicacaoServico.MarcarTarefaComoConcluida(dto);

					return Json(String.Format("Tarefa {0} marcada como 'Executada'!", dto.Nome),"application/json",Encoding.UTF8);
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

                    throw new ExcecaoTarefa(Json(erros,"application/json",Encoding.UTF8).ToString());
				}
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}
		}

		/// <summary>
		/// Lista todas as tarefas
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public ActionResult TodasAsTarefas(Nullable<long> idUsuario)
		{
			try
			{
				TarefaDto dto = new TarefaDto()
				{
					Usuario = new UsuarioDto()
					{
						Id = idUsuario
					}
				};

				ICollection<TarefaDto> dtos = tarefaAplicacaoServico.ListarTodasAsTarefasDoUsuario(dto);

				if (dtos != null && dtos.Count > 0)
				{
					ICollection<TarefaListarModel> models = Montador.MontaModeloDominioEViceVersa.Monta(dtos);

					return Json(new { TarefaModel = dtos },"application/json",Encoding.UTF8);
				}
				else
				{
                    return null;
				}
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}
		}

		[HttpGet]
		public ActionResult TarefasExecutadas(Nullable<long> idUsuario)
		{
			try
			{
                TarefaDto dto = new TarefaDto()
                {
                    Usuario = new UsuarioDto()
                    {
                        Id = idUsuario
                    }
                };

                ICollection<TarefaDto> dtos = tarefaAplicacaoServico.ListarTarefasConcluidas(dto);

                if (dtos != null && dtos.Count > 0)
                {
                    ICollection<TarefaListarModel> models = Montador.MontaModeloDominioEViceVersa.Monta(dtos);

                    return Json(new { TarefaModel = dtos }, "application/json", Encoding.UTF8);
                }
                else
                {
                    return null;
                }
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}
			
		}

		[HttpGet]
		public ActionResult TarefasVencidas(Nullable<long> idUsuario)
		{
			try
			{
                TarefaDto dto = new TarefaDto()
                {
                    Usuario = new UsuarioDto()
                    {
                        Id = idUsuario
                    }
                };

                ICollection<TarefaDto> dtos = tarefaAplicacaoServico.ListarTarefasAtrasadas(dto);

                if (dtos != null && dtos.Count > 0)
                {
                    ICollection<TarefaListarModel> models = Montador.MontaModeloDominioEViceVersa.Monta(dtos);

                    return Json(new { TarefaModel = dtos }, "application/json", Encoding.UTF8);
                }
                else
                {
                    return null;
                }
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}			
		}

		[HttpGet]
		public ActionResult TarefasAVencer(Nullable<long> idUsuario)
		{
			try
			{
                TarefaDto dto = new TarefaDto()
                {
                    Usuario = new UsuarioDto()
                    {
                        Id = idUsuario
                    }
                };

                ICollection<TarefaDto> dtos = tarefaAplicacaoServico.ListarTarefasAVencer(dto);

                if (dtos != null && dtos.Count > 0)
                {
                    ICollection<TarefaListarModel> models = Montador.MontaModeloDominioEViceVersa.Monta(dtos);

                    return Json(new { TarefaModel = dtos }, "application/json", Encoding.UTF8);
                }
                else
                {
                    return null;
                }
			}
			catch (ExcecaoTarefa et)
			{
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", et.Message) }, "application/json", Encoding.UTF8);
			}
			catch (Exception ex)
			{
				HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
				return Json(new { ExcecaoTarefa = String.Format("Erro: {0}", ex.Message) }, "application/json", Encoding.UTF8);
			}			
		}

		#endregion		
	}
}