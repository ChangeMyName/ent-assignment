using newsapp.Core.Config.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace newsapp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Initialize();

            PostAuthenticateRequest += Application_PostAuthenticateRequest;
        }

        private void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            if(HttpContext.Current.User != null)
            {
                string username = HttpContext.Current.User.Identity.Name;
                GenericPrincipal gp = new GenericPrincipal(HttpContext.Current.User.Identity, null);
                HttpContext.Current.User = gp;
            }
        }

    }
}
