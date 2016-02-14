using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Apresentacao.Mvc5.App_Start;

namespace Apresentacao.Mvc5
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
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}
