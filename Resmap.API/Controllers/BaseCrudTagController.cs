using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Helpers;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    public class BaseCrudTagController<TEntity, TEntityDto, TEntityForCreacteDto, TJoin> 
        : BaseCrudController<TEntity, TEntityDto, TEntityForCreacteDto>
        where TEntity : BaseEntity, ITaggable<TJoin>
        where TEntityDto : class
        where TEntityForCreacteDto : class, ITaggableDto        
        where TJoin : IEntityTag, new()
    {
        private readonly string IncludeExpression;
        public readonly ITagService _tagService;

        public BaseCrudTagController(
            string includeExpression,
            ITagService tagService,
            ICrudService<TEntity> crudService) : base(crudService)
        {
            IncludeExpression = includeExpression;
            _tagService = tagService;
        }

        [HttpGet()]
        public override IActionResult Get()
        {                     
            var entityFromRepo = _crudService.Get(IncludeExpression, true);
                     
            var response = Mapper.Map<IEnumerable<TEntityDto>>(entityFromRepo);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public override IActionResult Get(Guid id)
        {
            var entityFromRepo = _crudService.Get(id, IncludeExpression, true);

            if (entityFromRepo == null)
                return NotFound();

            var response = Mapper.Map<TEntityDto>(entityFromRepo);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public override IActionResult Delete(Guid id)
        {
            var entityFromRepo = _crudService.Get(id, IncludeExpression, true);

            if (entityFromRepo == null)
                return NotFound();

            _crudService.Delete(entityFromRepo);
            if (!_crudService.Save())
                throw new Exception($"Deleting entity {id} failed on save.");

            return NoContent();
        }

        [HttpPost()]
        public override IActionResult Create([FromBody] TEntityForCreacteDto entityToCreate)
        {
            var entityFromRepo = Mapper.Map<TEntityForCreacteDto, TEntity>(entityToCreate);
            _crudService.Create(entityFromRepo);

            var tags = Mapper.Map<ICollection<Tag>>(entityToCreate.Tags);                      

            TagsManager.AddTags(entityFromRepo.Tags, tags, entityFromRepo.Id, _tagService);
            
            if (!_crudService.Save())
                throw new Exception("Creating entity failed on save.");

            return Ok();
        }

        [HttpPut("{id}")]
        public override IActionResult Update(Guid id, [FromBody] TEntityForCreacteDto entityToUpdate)
        {
            var entityFromRepo = _crudService.Get(id, IncludeExpression, true);

            if (entityFromRepo == null)
                return NotFound();

            Mapper.Map(entityToUpdate, entityFromRepo);

            var tags = Mapper.Map<ICollection<Tag>>(entityToUpdate.Tags);
            TagsManager.AddTags(entityFromRepo.Tags, tags, entityFromRepo.Id, _tagService);
            
            if (!_crudService.Save())
                throw new Exception($"Updating entity {id} failed on save.");

            return NoContent();
        }

    }
}