using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AppContext = EMPSYS.DAL.Context.AppContext;

namespace EMPSYS.DAL
{
   public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppContext db;
        public BaseRepository(AppContext _db)
        {
            db = _db;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate);
        }
        public TEntity Find(int id)
        {
            return db.Set<TEntity>().Find(id);
        }
        public TEntity Get(object Id)
        {
            return db.Set<TEntity>().Find(Id);
        }
        public void Add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
        }
        public void AddRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().AddRange(entities);
        }
        public void Remove(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
        }
        public void Remove(object Id)
        {
            TEntity entity = db.Set<TEntity>().Find(Id);
            this.Remove(entity);
        }
        public void Update(TEntity entity)
        {
            //_context.Entry(employee).State = EntityState.Modified;
            db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
        public void UpdateRange(List<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                db.Entry<TEntity>(entity).State = EntityState.Modified;

            }
        }
    }
}
