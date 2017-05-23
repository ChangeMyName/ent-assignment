using newsapp.Data;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newsapp.Core.Commands;
using newsapp.Data.Entity;

namespace newsapp.Controllers
{
    public class JournalistsController : CRUDController<Journalist, IRepository>
    {
        public JournalistsController(IRepository repo) : base(repo)
        {

        }


        [HttpGet]
        public override ActionResult Index()
        {
            return base.Index();
        }

        [HttpGet]
        public override ActionResult Create()
        {
            return base.Create();
        }

        public override ActionResult Create(Journalist model)
        {
            return base.Create(model);
        }

        
        [HttpGet]
        public override ActionResult Update(int id)
        {
            return base.Update(id);
        }

        [HttpPost]
        public override ActionResult Delete(int id)
        {
            Delete(new DeleteCommand<Account>(Repo, id));
            return Delete(new DeleteCommand<Journalist>(Repo, id));
            
        }

    }
}