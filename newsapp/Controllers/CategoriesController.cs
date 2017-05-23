using newsapp.Data;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Controllers
{
    public class CategoriesController : BaseController<IRepository>
    {
        public CategoriesController(IRepository repo) : base(repo)
        {
        }
        
        public ActionResult Read(string name)
        {
            Category model = Repo.GetEntity<Category>(x => x.Name == name);
            return View(model);
        }

    }
}