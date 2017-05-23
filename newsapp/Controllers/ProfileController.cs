using newsapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Controllers
{
    [Authorize]
    public class ProfileController : BaseController<IRepository>
    {
        protected ProfileController(IRepository repo) : base(repo)
        {
        }

        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}