using newsapp.Controllers;
using newsapp.Data;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Controllers
{
    public class HomeController : BaseController<IRepository>
    {
        public HomeController(IRepository repo) : base(repo) { }

        public ActionResult Index()
        {
            IEnumerable<Category> cat = Repo.GetAll<Category>();

            return View(cat);
        }
    }
}