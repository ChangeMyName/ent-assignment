using newsapp.Core.Commands;
using newsapp.Data;
using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace newsapp.Core.Commands
{
    public class CreateCommand<TModel> : BaseRepoCommand<TModel> where TModel :class, IEntity
    {
        public CreateCommand(IRepository repo) : base(repo)
        {
        }

        public CreateCommand(IRepository repo, TModel model) : base(repo, model)
        {
        }

        public override void execute()
        {
            Repo.Create(Model);
            Repo.Save();
        }
    }
}