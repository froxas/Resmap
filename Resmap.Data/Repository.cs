using Microsoft.EntityFrameworkCore;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Resmap.Data
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

        public void Create(TEntity entity) => Context.Add(entity);

        public virtual TEntity Get(Guid id, bool eager = false)
            => Query(eager).SingleOrDefault(i => i.Id == id);        

        public virtual IEnumerable<TEntity> Get(bool eager = false)
            => Query(eager).ToList();

        public IQueryable<TEntity> Get(
            params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> query = dbSet;
            foreach (var includeExpression in includeExpressions)
                query = query.Include(includeExpression);

            return query;
        }

        public void Delete(TEntity entity) => Context.Remove(entity);       

        public bool Save() => (Context.SaveChanges() >= 0);

        public bool Exists(Guid id)
            => (Get(id) == null) ? false : true;        
        
        public IQueryable<TEntity> Query(bool eager = false)
        {
            var query = Context.Set<TEntity>().AsQueryable();
            if (eager)
            {             
                foreach (var property in Context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                {                       
                    query = query.Include(property.Name);                    
                }
            }
            return query;
        }
    }
}
