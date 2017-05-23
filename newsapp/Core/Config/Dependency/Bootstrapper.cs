using Microsoft.Practices.Unity;
using newsapp.Core.Security.Authentication;
using newsapp.Data;
using newsapp.Data.remote;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Core.Config.Dependency
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityResolver(container));
            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IRepository, GenericRepository<ArticlesDb>>();
            container.RegisterType<IAuthManager, Authentication<Account>>();
            return container;
        }
    }
}