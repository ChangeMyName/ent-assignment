using newsapp.Data;
using newsapp.Data.Entity;
using newsapp.Data.remote;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace newsapp.Models
{
    public abstract class BaseEntity : IEntity
    {
        protected IRepository Repo;
        public BaseEntity()
        {
            
        }
        public BaseEntity(IRepository repo)
        {
            Repo = repo;
        }

        public virtual void SetRepo(IRepository repo)
        {
            Repo = repo;
        }

        public virtual IEnumerable<TEntity> GetEntitiesOlderThan<TEntity>(DateTime time, ICollection<TEntity> collection) where TEntity: class, IWithDate
        {
            return collection.Where(x => x.GetDateCreated() < time);
        }

        public virtual TEntity GetLatestEntity<TEntity>(ICollection<TEntity> collection) where TEntity: class, IWithDate
        {
            return collection.OrderByDescending(x => x.GetDateCreated()).FirstOrDefault();
        }

        public void GenerateId()
        {
        }

        public bool Validate()
        {
            return true;
        }
    }
}