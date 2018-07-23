using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Helpers;
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
        ProjectForUpdateDto,
        ProjectTag
        >
    {        
        public ProjectController(
            ITagService tagService,
            ICrudService<Project> crudService) : base("ProjectTags.Tag", tagService, crudService)
        {     
        }        
        /*
        [HttpPost()]
        public override IActionResult Create([FromBody] ProjectForCreationDto entityToCreate)
        {
            var entityFromRepo = Mapper.Map<ProjectForCreationDto, Project>(entityToCreate);
            _crudService.Create(entityFromRepo);         
            
            var newTags = Mapper.Map<ICollection<Tag>>(entityToCreate.Tags);

            TagsManager.AddTags(entityFromRepo.ProjectTags, newTags, entityFromRepo.Id, _tagService);

            _crudService.Create(entityFromRepo);

            if (!_crudService.Save())
                throw new Exception("Creating entity failed on save.");

            return Ok();
        }        
        */
        [HttpPut("{id}")]
        public override IActionResult Update(Guid id, [FromBody] ProjectForUpdateDto entityToUpdate)
        {
            var entityFromRepo = _crudService.Get(id, "ProjectTags.Tag", true);

            if (entityFromRepo == null)
                return NotFound();

            Mapper.Map(entityToUpdate, entityFromRepo);

            var tagManager = new TagsManager();
            //tagManager.MapTags(_tagService, entityFromRepo, entityToUpdate);

            if (!_crudService.Save())
                throw new Exception($"Updating entity {id} failed on save.");

            return NoContent();
        }
    }

    
}