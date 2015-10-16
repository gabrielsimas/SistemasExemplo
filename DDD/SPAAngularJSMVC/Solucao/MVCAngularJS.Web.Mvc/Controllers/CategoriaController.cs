using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAngularJS.Aplicacao.Dto;
using MVCAngularJS.Aplicacao.Fachada;
using MVCAngularJS.Web.Mvc.Models;
using Newtonsoft.Json;

namespace MVCAngularJS.Web.Mvc.Controllers
{
	public class CategoriaController : Controller
	{
        ICategoriaApp app;
		//
		// GET: /Categoria/
		public ActionResult Index()
		{
			return View();
		}

        public CategoriaController(ICategoriaApp app)
        {
            this.app = app;
        }

		[HttpPost]
		public JsonResult CadastrarCategoria(CategoriaCadastroModel model)
		{
            if (model == null || String.IsNullOrEmpty(model.Nome))
            {
                return Json(new { successo = false, textoDeResposta = "Objet não pode ser vazio" }, JsonRequestBehavior.AllowGet);
            }

            try
            {                
                CategoriaDto dto = new CategoriaDto()
                {
                    Nome = model.Nome
                };
                
                app.Cadastrar(dto);

                return Json(new { successo = true, textoDeResposta = String.Format("Categoria {0} cadstrada com sucesso!", dto.Nome) }, JsonRequestBehavior.AllowGet);

                

            }catch(Exception ex){
                return Json(new { successo = false, textoDeResposta = String.Format("Erro ao cadastrar categoria {0}", ex.Message) }, JsonRequestBehavior.AllowGet);
            }
            
		}

		[HttpGet]        
		public JsonResult ListarTodasAsCategorias()
		{            
            ICollection<CategoriaDto> dtos;

            try
            {
                dtos = app.BuscarTodos();

                if (dtos != null && dtos.Count > 0)
                {
                    return Json(dtos, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new HttpException(403,"Nenhuma Categoria encontrada!");
                }
            }
            catch (Exception ex)
            {

                return Json(new { success = false, responseText = String.Format("Erro ao Listar todas as categorias {0}", ex.Message) }, JsonRequestBehavior.AllowGet);
            }
                        
		}

        [HttpGet]
        public JsonResult BuscarCategoriaPorId(int id)
        {
            try
            {
                CategoriaDto dto = app.BuscarPorId(id);

                if(dto != null){
                    return Json(dto, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    throw new HttpException(403, "Nenhuma Categoria encontrada!");
                }

            }catch(Exception ex){
                return Json(new { success = false, responseText = String.Format("Erro ao Listar a categoria pelo id {0}: {1}", ex.Message, id) }, JsonRequestBehavior.AllowGet);
            }
        }
	}
}