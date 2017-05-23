using newsapp.Core.Commands;
using newsapp.Data;
using newsapp.Data.Entity;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newsapp.Core.Security.Authentication;

namespace newsapp.Controllers
{
    public class CRUDController<TModel, TRepo> : BaseController<TRepo> where TModel : class, IEntity where TRepo : class, IRepository
    {

        protected string RedirectTo { get; set; }
        protected ICommand Command;

        public CRUDController(TRepo repo) : base(repo)
        {
            RedirectTo = "Index";
        }

        public CRUDController(TRepo repo, IAuthManager auth) : base(repo, auth)
        {
        }

        public virtual ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(TModel model)
        {
            return Create(model, new CreateCommand<TModel>(Repo, model));
        }

        [NonAction]
        protected virtual ActionResult Create(TModel model, ICommand command)
        {
            if (TrySaveModel(command))
            {
                return RedirectToAction(RedirectTo);
            }
            return View(model);
        }

        public virtual ActionResult Index()
        {
            IEnumerable<TModel> model = Repo.GetAll<TModel>();
            return View(model);
        }


        public virtual ActionResult Read(int id)
        {
            TModel model = Repo.GetEntity<TModel>(id);
            return View(model);
        }


        public virtual ActionResult Update(int id)
        {
            TModel model = Repo.GetEntity<TModel>(id);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Update(TModel model)
        {
            return Update(model, new UpdateCommand<TModel>(Repo, model));
        }

        [NonAction]
        public virtual ActionResult Update(TModel model, ICommand command)
        {
            if (TrySaveModel(command))
                return RedirectToAction(RedirectTo);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Delete(int id)
        {

            return Delete(new DeleteCommand<TModel>(Repo, id));
        }

        [NonAction]
        protected virtual ActionResult Delete(ICommand command)
        {
            if (TrySaveModel(command))
                return RedirectToAction(RedirectTo);
            return View();
        }

        protected virtual bool TrySaveModel(ICommand command)
        {
            if (ModelState.IsValid)
            {
                command.execute();
                return true;
            }
            return false;
        }
    }
}