using newsapp.Data.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace newsapp.Data.remote
{
    public class GenericReadOnlyRepository<TContext> : CRepository<TContext>, IReadOnlyRepository where TContext : DbContext
    {
        public GenericReadOnlyRepository(TContext ctx) : base(ctx)
        {
        }

        public virtual IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity: class, IEntity
        {
            var set = GetIQueryable<TEntity>();
            IEnumerable<TEntity> res = set.Where(filter);
            return res;
        }
        public virtual IEnumerable<TEntity> GetAll<TEntity>() where TEntity: class, IEntity
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            return query.ToList();
        }
        
        public virtual TEntity GetEntity<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity: class, IEntity
        {
            var set = GetIQueryable<TEntity>();
            IEnumerable<TEntity> res = set.Where(filter);
            return res.SingleOrDefault();
        }

        public virtual TEntity GetEntity<TEntity>(object id) where TEntity : class, IEntity
        {
            var set = GetDbSet<TEntity>();
            return set.Find(id);
        }
    }
}