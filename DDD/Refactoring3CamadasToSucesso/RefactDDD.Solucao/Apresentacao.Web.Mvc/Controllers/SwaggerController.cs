using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SwaggerAPIDocumentation.Interfaces;
using SwaggerAPIDocumentation;

namespace Apresentacao.Web.Mvc.Controllers
{
	public class SwaggerController : Controller
	{
		private readonly ISwaggerApiDocumentation documentacaoApi;

		public SwaggerController()
		{
			documentacaoApi = new SwaggerApiDocumentation<SwaggerController>();
		}

		// GET: /Swagger/
		[ActionName("Index")]
		public ActionResult Index(String name)
		{
			return !String.IsNullOrEmpty(name) ? this.Get(name) : this.Get();
		}

		public ActionResult Get()
		{
			return Content(documentacaoApi.GetSwaggerApiList(),"application/json");
		}

		public ActionResult Get(String name)
		{
			var controllerType = Type.GetType("Apresentacao.Web.Mvc.Controllers." + name + "Controller");
			return Content(documentacaoApi.GetControllerDocumentation(controllerType, "http://localhost:40624"), "application/json");
		}
	}
}