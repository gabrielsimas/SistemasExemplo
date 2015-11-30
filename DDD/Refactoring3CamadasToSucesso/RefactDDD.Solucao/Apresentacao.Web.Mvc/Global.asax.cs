using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Apresentacao.Web.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Remove todos os View Engines
            ViewEngines.Engines.Clear();

            //Adiciona apenas o Engine do Razor
            //ViewEngines.Engines.Add(new RazorViewEngine());

        }
    }
}
