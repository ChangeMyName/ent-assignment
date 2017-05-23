using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using newsapp.Data;
using newsapp.Data.Entity;

namespace newsapp.Core.Commands
{
    public class UpdateCommand<TModel> : BaseRepoCommand<TModel> where TModel : class, IEntity
    {
        public UpdateCommand(IRepository repo) : base(repo)
        {
        }

        public UpdateCommand(IRepository repo, TModel model) : base(repo, model)
        {
        }

        public override void execute()
        {
            Repo.Update(Model);
            Repo.Save();
        }
    }
}