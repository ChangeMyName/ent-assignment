using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace newsapp.Data.remote
{
    public abstract class CRepository<TContext> where TContext: DbContext
    {
        protected TContext Context { get;}
        
        public CRepository(TContext ctx)
        {
            Context = ctx;
        }

        protected virtual IQueryable<TEntity> GetIQueryable<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity: class, IEntity
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();
            if(filter != null)
            {
                query = query.Where(filter);
            }

            return query;
        }

        protected virtual DbSet<TEntity> GetDbSet<TEntity>() where TEntity: class, IEntity
        {
            return Context.Set<TEntity>();
        }

        protected virtual void Dispose()
        {
            Context.Dispose();
        }


    }
}