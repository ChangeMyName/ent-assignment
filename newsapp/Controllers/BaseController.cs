using newsapp.Core.Security.Authentication;
using newsapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Controllers
{
    public abstract class BaseController<TRepo> : Controller where TRepo : class, IRepository
    {
        protected IAuthManager Auth;
        protected TRepo Repo;
        
        protected BaseController(TRepo repo)
        {
            Repo = repo;
        }

        protected BaseController(TRepo repo, IAuthManager auth) : this (repo)
        {
            Auth = auth;
        }
    }
}