using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public interface IRepository<TEntity> : IDisposable
    where TEntity : class
    {
        TEntity Add(TEntity toCreate);
        bool Delete(TEntity toDelete);
        bool Update(TEntity toUpdate);
        TEntity GetForId(Expression<Func<TEntity, bool>> criteria);
        List<TEntity> GetAllForGroupId(Expression<Func<TEntity, bool>> criteria);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria);
    }
}
