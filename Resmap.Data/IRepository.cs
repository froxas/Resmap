using Microsoft.EntityFrameworkCore;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Resmap.Data
{    
    /// <summary>
    /// Generic repository for CRUD services
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        DbContext Context { get; }
                
        /// <summary>
        /// Gets a single entity by id 
        /// with eager false or true
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eager"></param>
        /// <returns></returns>
        TEntity Get(Guid id, bool eager = false);

        /// <summary>
        /// Reads all entities
        /// with eager false or true
        /// </summary>
        /// <param name="eager"></param>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(bool eager = false);

        /// <summary>
        /// Reads all entities with includ expression
        /// </summary>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAllIncludes(params Expression<Func<TEntity, object>>[] includeExpressions);

        /// <summary>
        /// Adds entity to db
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// Deletes entity from db
        /// </summary>
        /// <param name="id"></param>
        void Delete(TEntity Entity);

        /// <summary>
        /// Reads entity by id and returns with all includes
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        TEntity GetById(
            Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeExpressions);

        /// <summary>
        /// Returns true if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(Guid id);

        /// <summary>
        /// Saves entity added to context to db
        /// </summary>
        /// <returns></returns>
        bool Save();
              
    }
}
