using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Resmap.API.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        public DbContext Context { get;}        
        private DbSet<TEntity> dbSet;        

        public Repository(DbContext context)
        {
            Context = context;
            dbSet = Context.Set<TEntity>();
        }       

        public void Add(TEntity entity) => Context.Add(entity);
             
        public TEntity Get(Guid id) => dbSet.Find(id);

        public IEnumerable<TEntity> GetAll() => dbSet.ToList();

        public void Delete(TEntity entity) => Context.Remove(entity);

        public bool Save() => (Context.SaveChanges() >= 0);
        
        public IQueryable<TEntity> GetAllIncludes(
            params Expression<Func<TEntity, object>>[] includeExpressions)
        {            
            IQueryable<TEntity> query = dbSet;

            foreach (var includeExpression in includeExpressions)            
                query = query.Include(includeExpression);

            return query;
        }       

        public TEntity GetById(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            if (includeExpressions.Any())
            {
                var set = includeExpressions
                  .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>
                    (dbSet, (current, expression) => current.Include(expression));

                return set.SingleOrDefault(predicate);
            }

            return dbSet.FirstOrDefault(predicate);
        }                                
    }
}
