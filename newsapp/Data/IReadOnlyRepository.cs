using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace newsapp.Data
{
    //public interface IReadOnlyRepository<TEntity>
    //{
    //    IEnumerable<TEntity> GetAll();
    //    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
    //    TEntity GetEntity(Expression<Func<TEntity, bool>> filter);
    //    TEntity GetEntity(object id);
    //}

    public interface IReadOnlyRepository
    {
        IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class, IEntity;
        IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity;
        TEntity GetEntity<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity;
        TEntity GetEntity<TEntity>(object id) where TEntity : class, IEntity;
    }
}
