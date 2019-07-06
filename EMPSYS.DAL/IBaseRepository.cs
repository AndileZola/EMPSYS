using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EMPSYS.DAL
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(int id);
        TEntity Get(object Id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Remove(object Id);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
								TEntity EagerGetSingle(Expression<Func<TEntity, bool>> predicate, List<string> navigationProperties);
				IEnumerable<TEntity> EagerGetList(Expression<Func<TEntity, bool>> predicate, List<string> navigationProperties);

				}
}
