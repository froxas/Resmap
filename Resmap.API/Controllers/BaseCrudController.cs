using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Controllers.Infrastructure;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    public class BaseCrudController<TEntity, TEntityDto, TEntityForCreacteDto, TEntityForUpdateDto> : Controller
        where TEntity : BaseEntity
        where TEntityDto : class
        where TEntityForCreacteDto : class
        where TEntityForUpdateDto : class
    {
        public readonly ICrudService<TEntity> _crudService;

        public BaseCrudController(ICrudService<TEntity> crudService)
            => _crudService = crudService;        
          
        [HttpGet]
        public virtual IActionResult Get()
        {
            var entityFromRepo = _crudService.Get(true);
            var response = Mapper.Map<IEnumerable<TEntityDto>>(entityFromRepo);

            return Ok(response);
        }
        
        [HttpGet("{id}")]       
        public virtual IActionResult Get(Guid id)
        {
            var entityFromRepo = _crudService.Get(id, true);

            if (entityFromRepo == null)
                return NotFound();

            var response = Mapper.Map<TEntityDto>(entityFromRepo);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(Guid id)
        {
            var entityFromRepo = _crudService.Get(id, true);

            if (entityFromRepo == null)
                return NotFound();

            _crudService.Delete(entityFromRepo);
            if (!_crudService.Save())
                throw new Exception($"Deleting entity {id} failed on save.");

            return NoContent();
        }
        
        [HttpPost()]       
        public virtual IActionResult Create([FromBody] TEntityForCreacteDto entityToCreate)
        {            
            var entityFromRepo = Mapper.Map<TEntityForCreacteDto, TEntity>(entityToCreate);
            _crudService.Create(entityFromRepo);

            if (!_crudService.Save())
                throw new Exception("Creating entity failed on save.");            

            return NoContent();
        }        
      
        [HttpPut("{id}")]        
        public virtual IActionResult Update(Guid id, [FromBody] TEntityForUpdateDto entityToUpdate)
        {            

            var entityFromRepo = _crudService.Get(id, true);

            if (entityFromRepo == null)
                return NotFound();

            Mapper.Map(entityToUpdate, entityFromRepo);

            if (!_crudService.Save())
                throw new Exception($"Updating entity {id} failed on save.");

            return NoContent();
        }        
    }
}