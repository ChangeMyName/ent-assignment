using newsapp.Data;
using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newsapp.Core.Commands
{
    public abstract class BaseRepoCommand<TModel> : ICommand where TModel : class, IEntity
    {
        protected IRepository Repo;
        protected TModel Model;
        
        public BaseRepoCommand(IRepository repo)
        {
            Repo = repo;
        }
        public BaseRepoCommand(IRepository repo, TModel model): this(repo)
        {
            Model = model;
        }

        public virtual void execute()
        {

        }
    }
}