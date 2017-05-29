using newsapp.Core.Security.Authentication;
using newsapp.Data;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace newsapp.Controllers
{
    public class AccountsController : CRUDController<Account, IRepository>
    {
        public AccountsController(IRepository repo, IAuthManager auth) : base(repo, auth)
        {
        }

        [HttpGet]   
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Journalist j = new Journalist()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description,
                    Email = model.Email,
                    Image = model.Image
                };
                Repo.Create(j).Save();
                Account acc = new Account()
                {
                    Username = model.Username,
                    Password = model.Password,
                    Id = j.Id
                };
                Repo.Create(acc).Save();
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Auth.Login(model.Username, model.Password) == AuthStatus.OK)
                {
                    ViewBag.Journalist = Auth.GetUser();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Auth.Logout();
            return RedirectToAction("Index", "Home");
        }

    }
}