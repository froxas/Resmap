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
    /// in order to implement additional features to CRUD operations
    /// IRepository methods should be overided
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        DbContext Context { get; }

        /// <summary>
        /// Adds entity to db
        /// </summary>
        /// <param name="entity"></param>
        void Create(TEntity entity);

        /// <summary>
        /// Gets a single entity by id with eager false or true        
        /// </summary>
        /// <param name="id"></param>
        /// <param name="eager"></param>
        /// <returns></returns>
        TEntity Get(Guid id, bool eager = false);

        /// <summary>
        /// Gets a single entity by id with eager false or true  
        /// and included many-to-many reations. 
        /// e.g. specifying a query string "Tags.Tag"
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeQuery"></param>
        /// <param name="eager"></param>
        /// <returns></returns>
        TEntity Get(Guid id, string includeQuery, bool eager = false);

        /// <summary>
        /// Gets all entities with eager false or true
        /// </summary>
        /// <param name="eager"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(bool eager = false);

        /// <summary>
        /// Gets all entities with eager false or true
        /// and included many-to-many relations. 
        /// e.g. specifying in a string "Tags.Tag"
        /// </summary>
        /// <param name="eager"></param>
        /// <param name="includeQuery"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(string includeQuery, bool eager = false);

        /// <summary>
        /// Gets all entities with eager false or true
        /// and included many-to-many relations. 
        /// e.g. specifying a query string "Tags.Tag"
        /// apply where with expression
        /// </summary>
        /// <param name="includeQuery"></param>
        /// <param name="expression"></param>
        /// <param name="eager"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Get(string includeQuery, Func<TEntity, bool> expression, bool eager = false);

        /// <summary>
        /// Reads query of all entities with multiple include statements 
        /// </summary>
        /// <param name="includeExpressions"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(params Expression<Func<TEntity, object>>[] includeExpressions);

        /// <summary>
        /// Deletes entity from db
        /// </summary>
        /// <param name="id"></param>
        void Delete(TEntity Entity);

        /// <summary>
        /// Saves entity added to context to db
        /// </summary>
        /// <returns></returns>
        bool Save();

        /// <summary>
        /// Returns true if entity exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(Guid id);       
    }
}
