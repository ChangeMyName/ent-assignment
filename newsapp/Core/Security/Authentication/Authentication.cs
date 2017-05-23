using newsapp.Data;
using newsapp.Data.Entity;
using newsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Linq.Expressions;
using newsapp.Data.remote;
using System.Data.Entity;

namespace newsapp.Core.Security.Authentication
{
    public enum AuthStatus
    {
        OK,
        FAILED
    }

    public interface IAuthManager
    {
        AuthStatus Login(string username, string password);
        void Logout();
        AppUser GetUser();
    }

    public class Authentication<TModel> : IAuthManager  where TModel : AppUser
    {
        private IPasswordHasher passwordHasher;
        private IRepository repo;
        public static TModel User;
        public Authentication(IRepository repo)
        {
            this.repo = repo;
        }

        public AppUser GetUser()
        {
            return User;
        }

        public AuthStatus Login(string username, string password)
        {
            if (!Validate(username) && !Validate(password)) return AuthStatus.FAILED;
            User = repo.GetEntity<TModel>(x => x.Username.Equals(username) && x.Password.Equals(password));

            if (User != null)
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return AuthStatus.OK;
            }

            return AuthStatus.FAILED;
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private bool Validate(string str)
        {
            if (str == null || string.Empty.Equals(str))
            {
                return false;
            }

            return true;
        }
    }
}