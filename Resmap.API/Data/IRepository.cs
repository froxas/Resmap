using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Resmap.API.Data
{    
    /// <summary>
    /// Generic repository to CRUD services
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity: class
    {
        DbContext Context { get; }

        /// <summary>
        /// Reads a single entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Get(Guid id);

        /// <summary>
        /// Read all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

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
        /// Saves entity added to context to db
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
