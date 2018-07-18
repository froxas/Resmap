﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    public class BaseCrudTagController<TEntity, TEntityDto, TEntityForCreacteDto, TEntityForUpdateDto, TJoin> 
        : BaseCrudController<TEntity, TEntityDto, TEntityForCreacteDto, TEntityForUpdateDto>
        where TEntity : BaseEntity, ITaggable
        where TEntityDto : class
        where TEntityForCreacteDto : class
        where TEntityForUpdateDto : class    
        where TJoin : JoinEntity<TEntity>, new()
    {
        private readonly string IncludeExpression;
        public readonly ITagService<TEntity, TJoin> _tagService;

        public BaseCrudTagController(
            string includeExpression,
            ITagService<TEntity, TJoin> tagService,
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

        [HttpDelete()]
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
    }
}