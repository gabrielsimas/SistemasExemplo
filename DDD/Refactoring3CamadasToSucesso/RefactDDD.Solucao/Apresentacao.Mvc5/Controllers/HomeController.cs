using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao.Dto;
using Aplicacao.Servico.Fachada;
using Apresentacao.Mvc5.Excecao;
using Apresentacao.Mvc5.Models;


namespace Apresentacao.Mvc5.Controllers
{
	public class HomeController : ControllerPai
	{
		#region Atributos
		private readonly ITarefaAplicServico tarefaAplicacaoServico;
		private readonly IUsuarioAplicServico usuarioAplicacaoServico;		

		#endregion

		#region Construtor
		public HomeController (ITarefaAplicServico tarefaAplicacaoServico, IUsuarioAplicServico usuarioAplicacaoServico)
		{
			this.tarefaAplicacaoServico = tarefaAplicacaoServico;
			this.usuarioAplicacaoServico = usuarioAplicacaoServico;
		}
		#endregion

		#region Actions
		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CadastrarNovoUsuario(UsuarioCadastroModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{
					UsuarioDto dto = new UsuarioDto();
					dto = Mapeador.Map<UsuarioDto>(model);

					usuarioAplicacaoServico.CadastrarNovoUsuario(dto);

					dto.senha = null;

					ViewBag.MensagemCriacaoUsuario = "Usuario " + model.Login + " criado com sucesso!";

					return null;
				}
			}
			catch (ExcecaoUsuario eu)
			{
				ViewBag.MensagemCriacaoUsuario = eu.Message;
			}
			catch (Exception ex)
			{
				ViewBag.MensagemCriacaoUsuario = ex.Message;
			}

			return null;
		}

		[HttpPost]
		public ActionResult Autenticar(AutenticacaoModel model)
		{
			try
			{
				if (ModelState.IsValid)
				{					 

					if (usuarioAplicacaoServico.AutenticarUsuario(Mapeador.Map<UsuarioDto>(model)))
					{
						UsuarioDto resultado = usuarioAplicacaoServico.BuscarUsuarioPorLogin(Mapeador.Map<UsuarioDto>(model));
						resultado.senha = null;

						if (resultado.Id.HasValue)
						{
							PainelDeTarefaModel painelDeTarefasModel = new PainelDeTarefaModel();
							String idUsuarioSession;
							Session["idUsuario"] = resultado.Id;
							Session["LoginUsuario"] = resultado.Login;

							idUsuarioSession = Session["idUsuario"].ToString();

							painelDeTarefasModel = this.MontaPainelDeTarefas(int.Parse(idUsuarioSession));

							if (painelDeTarefasModel != null)
							{
								return View("Painel", painelDeTarefasModel);
							}
							else
							{
								return View("Painel");
							}

							
						}
						else
						{
							throw new ExcecaoAutenticacao("Houve um problema na Autenticação: Erro ao localizar o Login do Usuário");
						}

					}
				}
			}
			catch (ExcecaoAutenticacao ea)
			{
				ViewBag.Mensagem = ea.Message;
			}
			catch (Exception ex)
			{
				ViewBag.Mensagem = ex.Message;
			}
			return null;
		}

		public ActionResult Executar(Nullable<long> idTarefa)
		{
			TarefaDto dto;
			PainelDeTarefaModel painel = new PainelDeTarefaModel();
			string idUsuarioSession;

			if (idTarefa.HasValue)
			{
				dto = new TarefaDto();
				idUsuarioSession = Session["idUsuario"].ToString();

				dto = tarefaAplicacaoServico.BuscarTarefa(new TarefaDto() { Id = idTarefa.Value});

				if(dto != null)
				{
					if (dto.Id.HasValue)
					{
						this.tarefaAplicacaoServico.MarcarTarefaComoConcluida(dto);
					}
				}

				painel = this.MontaPainelDeTarefas(int.Parse(idUsuarioSession));

				if (painel != null)
				{
					return View("Painel",painel);
				}
				else
				{
					return null;
				}
			}
			else
			{
				return null;
			}
			
		}

		[HttpPost]
		public JsonResult CadastrarTarefa(TarefaCadastroModel model)
		{
			try
			{
				PainelDeTarefaModel painelDeTarefasModel;
				ModelState.Clear();
				TarefaDto dto = new TarefaDto();
				model.IdUsuario = int.Parse(Session["IdUsuario"].ToString());

				dto = Mapeador.Map<TarefaDto>(model);

				if (dto != null)
				{                    
					this.tarefaAplicacaoServico.CadastrarTarefa(dto);

					painelDeTarefasModel = this.MontaPainelDeTarefas(dto.IdUsuario.Value);

					return Json("Tarefa " + model.Nome + " cadastrada com sucesso!");
				}
				else
				{
					return null;
				}                     
			}
			catch (DbEntityValidationException e)
			{
				String erro = String.Empty;
				foreach (var eve in e.EntityValidationErrors)
				{
					 erro += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
						eve.Entry.Entity.GetType().Name, eve.Entry.State);
					foreach (var ve in eve.ValidationErrors)
					{
						erro += String.Format("- Property: \"{0}\", Error: \"{1}\"",
							ve.PropertyName, ve.ErrorMessage);
					}
				}
				return Json(erro.ToString());
			}
			catch(Exception ex)
			{
				return Json(ex.Message);
			}
		}

		[HttpPatch]
		public ActionResult MarcarTarefaComoConcluida(TarefaEdicaoModel model)
		{
			return null;
		}

		#endregion

		#region Métodos Auxiliares

		public PainelDeTarefaModel MontaPainelDeTarefas(Nullable<long> id)
		{
			if (id > 0)
			{
				PainelDeTarefaModel model = new PainelDeTarefaModel();
				model.TarefasAVencer = this.TarefasAVencer(id);
				model.TarefasExecutadas = this.TarefasExecutadas(id);
				model.TarefasVencidas = this.TarefasVencidas(id);
				model.TodasAsTarefas = new List<TarefaListarModel>();

				model.TodasAsTarefas = this.TodasAsTarefas(id);

				return model;
			}
			else
			{
				if (Session["idUsuario"] != null)
				{
					Session.Clear();
					Session.Abandon();
				}
				return null;
			}
		}

		public ICollection<TarefaListarModel> TodasAsTarefas(Nullable<long> idUsuario)
		{
			TarefaDto dto;

			ICollection<TarefaDto> listaTodasAsTarefasDto = new List<TarefaDto>();
			ICollection<TarefaListarModel> listaTodasAsTarefas = new List<TarefaListarModel>();

			dto = new TarefaDto
			{
				Usuario = new UsuarioDto()
				{
					Id = idUsuario
				}
			};

			listaTodasAsTarefasDto = tarefaAplicacaoServico.ListarTodasAsTarefasDoUsuario(dto);

			if (listaTodasAsTarefasDto != null && listaTodasAsTarefasDto.Count > 0)
			{
				//foreach (var linha in listaTodasAsTarefasDto){
				//    linha.Usuario = new UsuarioDto() { Id = idUsuario };
				//}

				//listaTodasAsTarefas = Montador.MontaModeloDominioEViceVersa.Monta(listaTodasAsTarefasDto);
				return Mapeador.Map<ICollection<TarefaDto>,ICollection<TarefaListarModel>>(listaTodasAsTarefasDto);
			}
			else
			{
				return null;
			}
		}

		public ICollection<TarefaListarModel> TarefasAVencer(Nullable<long> idUsuario)
		{
			TarefaDto dto;
			ICollection<TarefaDto> listaTarefasAVencerDto = new List<TarefaDto>();
			ICollection<TarefaListarModel> listaTarefasAVencer = new List<TarefaListarModel>();

			dto = new TarefaDto
			{
				Usuario = new UsuarioDto()
				{
					Id = idUsuario
				}
			};

			listaTarefasAVencerDto = tarefaAplicacaoServico.ListarTarefasAVencer(dto);

			if (listaTarefasAVencerDto != null && listaTarefasAVencerDto.Count > 0)
			{
				//foreach (var linha in listaTarefasAVencerDto)
				//{
				//    linha.Usuario = new UsuarioDto() { Id = idUsuario };
				//}

				//listaTarefasAVencer = Montador.MontaModeloDominioEViceVersa.Monta(listaTarefasAVencerDto);
				return Mapeador.Map<ICollection<TarefaDto>, ICollection<TarefaListarModel>>(listaTarefasAVencerDto);
			}
			else
			{
				return null;
			}
		}

		public ICollection<TarefaListarModel> TarefasExecutadas(Nullable<long> idUsuario)
		{
			TarefaDto dto;
			ICollection<TarefaDto> listaTarefasExecutadasDto = new List<TarefaDto>();
			ICollection<TarefaListarModel> listaTarefasExecutadas = new List<TarefaListarModel>();

			dto = new TarefaDto
			{
				Usuario = new UsuarioDto()
				{
					Id = idUsuario
				}
			};

			listaTarefasExecutadasDto = tarefaAplicacaoServico.ListarTarefasConcluidas(dto);

			if (listaTarefasExecutadasDto != null && listaTarefasExecutadasDto.Count > 0)
			{
				//foreach (var linha in listaTarefasExecutadasDto)
				//{
				//    linha.Usuario = new UsuarioDto() { Id = idUsuario };
				//}

				//listaTarefasExecutadas = Montador.MontaModeloDominioEViceVersa.Monta(listaTarefasExecutadasDto);
				//return listaTarefasExecutadas;
				return Mapeador.Map<ICollection<TarefaDto>, ICollection<TarefaListarModel>>(listaTarefasExecutadasDto);
			}

			return null;
		}
		public ICollection<TarefaListarModel> TarefasVencidas(Nullable<long> idUsuario)
		{
			TarefaDto dto;
			ICollection<TarefaDto> listaTarefasVencidasDto = new List<TarefaDto>();
			ICollection<TarefaListarModel> listaTarefasVencidas = new List<TarefaListarModel>();

			dto = new TarefaDto
			{
				Usuario = new UsuarioDto()
				{
					Id = idUsuario
				}
			};

			listaTarefasVencidasDto = tarefaAplicacaoServico.ListarTarefasAtrasadas(dto);

			if (listaTarefasVencidasDto != null && listaTarefasVencidasDto.Count > 0)
			{
				//foreach (var linha in listaTarefasVencidasDto)
				//{
				//    linha.Usuario = new UsuarioDto() { Id = idUsuario };
				//}

				//listaTarefasVencidas = Montador.MontaModeloDominioEViceVersa.Monta(listaTarefasVencidasDto);
				//return listaTarefasVencidas;
				return Mapeador.Map<ICollection<TarefaDto>,ICollection<TarefaListarModel>>(listaTarefasVencidasDto);
			}

			return null;
		}

		#endregion		
	}
}