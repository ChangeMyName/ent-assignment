using newsapp.Data;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Controllers
{
    public class AuthorsController : BaseController<IRepository>
    {
        public AuthorsController(IRepository repo) : base(repo)
        {
        }

        public ActionResult Read(string fullname)
        {
            Journalist model = Repo.GetEntity<Journalist>(x => (x.FirstName + x.LastName).Equals(fullname));

            if (model == null) return HttpNotFound();
            return View(model);
        }

    }
}