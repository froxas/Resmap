using Microsoft.AspNetCore.Mvc;
using Resmap.Domain;
using System;

namespace Resmap.API.Controllers
{
    /// <summary>
    /// Generic Base controller for to manage Crud operatios for TEntity
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    /// <typeparam name="TEntityDto">View model for to show TEntity</typeparam>
    /// <typeparam name="TEntityForCreacteDto">View model for to create TEntity</typeparam>
    /// <typeparam name="TEntityForCreacteDto">View model for to update TEntity</typeparam>
    public interface IBaseCrudController<TEntity, TEntityDto, TEntityForCreacteDto, TEntityForUpdateDto>
        where TEntity : BaseEntity
        where TEntityDto : class
        where TEntityForCreacteDto : class
        where TEntityForUpdateDto : class
    {
        /// <summary>
        /// Get all entities of TEntity included all navigation properties
        /// </summary>
        /// <returns>response object with TEntityDto view model</returns>
        IActionResult Get();

        /// <summary>
        /// Get entity by Id of TEntity included all navigation properties
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>        
        IActionResult Get(Guid id);

        /// <summary>
        /// Deletes entity of TEntity with all included properties
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>        
        IActionResult Delete(Guid id);

        /// <summary>
        /// Creates entity of TEntity
        /// </summary>
        /// <param name="entityToCreate"></param>
        /// <returns>NoContent</returns>        
        IActionResult Create([FromBody] TEntityForCreacteDto entityToCreate);

        /// <summary>
        /// Updates entity of TEntity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityToUpdate"></param>
        /// <returns>NoContent</returns>        
        IActionResult Update(Guid id, [FromBody] TEntityForUpdateDto entityToUpdate);
    }
}