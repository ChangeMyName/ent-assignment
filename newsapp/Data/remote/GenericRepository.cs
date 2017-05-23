using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace newsapp.Data.remote
{
    public class GenericRepository<TContext> : GenericReadOnlyRepository<TContext>, IRepository where TContext : DbContext
    {
        public GenericRepository(TContext ctx) : base(ctx)
        {
        }
        
        public virtual void Delete<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity: class, IEntity
        {
            var query = GetIQueryable<TEntity>();
            IEnumerable<TEntity> q = query.Where(filter);

            var set = GetDbSet<TEntity>();
            set.RemoveRange(q);
        }

        public virtual void Delete<TEntity>(object id) where TEntity: class, IEntity
        {
            //var set = ctx.Set<TEntity>();
            var set = GetDbSet<TEntity>();
            var tmp = set.Find(id);
            if (tmp == null) return;
            Delete(tmp);
        }

        public virtual void Delete<TEntity>(TEntity ent) where TEntity : class, IEntity
        {
            //var set = ctx.Set<TEntity>();
            var set = GetDbSet<TEntity>();
            set.Remove(ent);
        }

        
        public virtual IRepository Create<TEntity>(TEntity ent) where TEntity: class, IEntity
        {
            //var set = ctx.Set<TEntity>();
            var set = GetDbSet<TEntity>();
            set.Add(ent);

            return this;
        }

        public virtual void Update<TEntity>(TEntity ent) where TEntity : class, IEntity
        {
            //ctx.Set<TEntity>().Attach(ent);
            var set = GetDbSet<TEntity>().Attach(ent);
            Context.Entry(ent).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            Context.SaveChanges();
            //Dispose();
            //Context.Dispose();
        }
        public virtual TReturn Save<TReturn, TEntity>(IRepositoryCallback<TReturn, TEntity> cb) where TReturn : class where TEntity :class, IEntity
        {
            try
            {
                Save();
                return cb.onWrite(true);
            }
            catch (Exception e)
            {
                return cb.onWrite(false);

            }

        }

        void IRepository.Delete<TEntity, TIdentity>(TIdentity id)
        {
            var set = GetDbSet<TEntity>();

            var tmp = set.Find(id);
            Delete(tmp);
        }
    }
}