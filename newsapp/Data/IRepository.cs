using newsapp.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace newsapp.Data
{
    public interface IRepositoryCallback<TReturn, TEntity> where TReturn:class where TEntity: class, IEntity{
        TReturn onWrite(bool isSuccess);
        TReturn onRead(TEntity model);
        TReturn onRead(IEnumerable<TEntity> model);
    }
    public interface IRepository : IReadOnlyRepository
    {
        void Delete<TEntity>(Expression<Func<TEntity, bool>> filter) where TEntity : class, IEntity;
        void Delete<TEntity>(object id) where TEntity: class, IEntity;
        void Delete<TEntity, TIdentity>(TIdentity id) where TEntity : class, IEntity where TIdentity : IComparable;
        void Delete<TEntity>(TEntity ent) where TEntity: class, IEntity;
        void Save();
        TReturn Save<TReturn, TEntity>(IRepositoryCallback<TReturn, TEntity> cb) where TReturn : class where TEntity : class, IEntity;
        IRepository Create<TEntity>(TEntity ent) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity ent) where TEntity : class, IEntity;
    }
}
