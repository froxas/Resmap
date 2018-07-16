using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Controllers
{
    [Route("api/projects")]
    public class ProjectController : BaseCrudTagController<
        Project, 
        ProjectDto, 
        ProjectForCreationDto, 
        ProjectForUpdateDto>
    {        
        public ProjectController(
            ICrudService<Project> crudService) : base("ProjectTags.Tag", crudService)
        {     
        }        

        [HttpPost()]
        public override IActionResult Create([FromBody] ProjectForCreationDto entityToCreate)
        {
            var eventEntity = Mapper.Map<ProjectForCreationDto, Project>(entityToCreate);           

            _crudService.Create(eventEntity);

            if (!_crudService.Save())
                throw new Exception("Creating entity failed on save.");

            return Ok();
        }

        [HttpPut("{id}")]
        public override IActionResult Update(Guid id, [FromBody] ProjectForUpdateDto entityToUpdate)
        {
            var entityFromRepo = _crudService.Get(id, "ProjectTags.Tag", true);

            if (entityFromRepo == null)
                return NotFound();

           // _tagService.MapTags(entityFromRepo, entityToUpdate);

            Mapper.Map(entityToUpdate, entityFromRepo);

            if (!_crudService.Save())
                throw new Exception($"Updating entity {id} failed on save.");

            return NoContent();
        }
    }
}