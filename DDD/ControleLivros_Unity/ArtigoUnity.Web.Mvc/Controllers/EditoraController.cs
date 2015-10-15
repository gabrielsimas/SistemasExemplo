using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArtigoUnity.Aplicacao.Servico.Fachada;

namespace ArtigoUnity.Web.Mvc.Controllers
{
	public class EditoraController : Controller
	{
		private IEditoraAplicServico editoraServico;

		public EditoraController(IEditoraAplicServico servico)
		{
			this.editoraServico = servico;
		}
		//
		// GET: /Editora/
		public ActionResult Index()
		{
			return View();
		}
	}
}