using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using newsapp.Data;
using newsapp.Data.Entity;

namespace newsapp.Core.Commands
{
    public class DeleteCommand<TModel> : BaseRepoCommand<TModel> where TModel : class, IEntity
    {
        private int id;
        public DeleteCommand(IRepository repo, int id) : base(repo)
        {
            this.id = id;
        }
        public DeleteCommand(IRepository repo) : base(repo)
        {
        }

        public DeleteCommand(IRepository repo, TModel model) : base(repo, model)
        {
        }


        public override void execute()
        {
            Repo.Delete<TModel>(id);
            Repo.Save();
        }
    }
}