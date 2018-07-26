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

        public virtual TEntity Get(Guid id, string includeQuery, bool eager = false)
            => Query(eager).Include(includeQuery).SingleOrDefault(i => i.Id == id);

        public virtual IEnumerable<TEntity> Get(bool eager = false)
            => Query(eager).ToList();

        public IEnumerable<TEntity> Get(string includeQuery, bool eager = false)
            => Query(eager).Include(includeQuery).ToList();

        public IEnumerable<TEntity> Get(string includeQuery, Func<TEntity, bool> expression, bool eager = false)
            => Query(eager).Include(includeQuery).Where(expression).ToList();

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
