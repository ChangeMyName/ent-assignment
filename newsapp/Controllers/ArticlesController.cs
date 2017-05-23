using newsapp.Core.Security.Authentication;
using newsapp.Data;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsapp.Controllers
{
    public enum ViewBagID
    {
        Category,
        Country,
        TotalIds
    }

    [Authorize]
    public class ArticlesController : CRUDController<Article, IRepository>
    {
        public ArticlesController(IRepository repo) : base(repo)
        {
        }

        [HttpGet]
        public override ActionResult Index()
        {
            
            //ViewData.Add("Countries", (IEnumerable<Country>)countries);
            //ViewData.Add("Categories", (IEnumerable<Category>)categories);
            return base.Index();
        }

        [HttpGet]
        public override ActionResult Create()
        {
            ViewData.Add(ViewBagID.Country.ToString(), Country.GetAllCountries(Repo));
            ViewData.Add(ViewBagID.Category.ToString(), Category.GetAllCategories(Repo));

            return base.Create();
        }

        public override ActionResult Create(Article model)
        {
            model.PostedOn = DateTime.Now;
            model.JournalistId = Authentication<Account>.User.Id;
            return base.Create(model);
        }

        public override ActionResult Read(int id)
        {
            return base.Read(id);
        }

        [HttpGet]
        public override ActionResult Update(int id)
        {
            ViewData.Add(ViewBagID.Country.ToString(), Country.GetAllCountries(Repo));
            ViewData.Add(ViewBagID.Category.ToString(), Category.GetAllCategories(Repo));
            return base.Update(id);
        }

        [HttpPost]
        public override ActionResult Update(Article model)
        {
            model.PostedOn = DateTime.Now;
            return base.Update(model);
        }


        [HttpPost]
        public override ActionResult Delete(int id)
        {
            return base.Delete(id);
        }
    }
}