using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Resmap.API.Controllers.Infrastructure;
using Resmap.API.Models;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Controllers
{
    [Route("api/projects")]
    public class ProjectController : BaseCrudController<Project, ProjectDto, ProjectForCreationDto>
    {
        private readonly ITagService _tagService;

        public ProjectController(         
            ITagService tagService,
            ICrudService<Project> crudService) : base(crudService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public override IActionResult Get()
        {
            var entityFromRepo = _crudService.Get("ProjectTags.Tag", true);              
            var response = Mapper.Map<IEnumerable<ProjectDto>>(entityFromRepo);

            return Ok(response);            
        }

        [HttpGet("{id}")]
        public override IActionResult Get(Guid id)
        {
            var entityFromRepo = _crudService.Get(id, "ProjectTags.Tag", true);

            if (entityFromRepo == null)
                return NotFound();

            var response = Mapper.Map<ProjectDto>(entityFromRepo);

            return Ok(response);         
        }

        [HttpPost()]        
        public override IActionResult Create([FromBody] ProjectForCreationDto entityToCreate)
        {
            // 1. Map to project
            var projectEntity = Mapper.Map<ProjectForCreationDto, Project>(entityToCreate);

            // 2. Save new project
            _crudService.Create(projectEntity);
            if (!_crudService.Save())
                throw new Exception("Creating entity failed on save.");

            // 4. map ProjectTags

          

            //add newly created tags
           

            //add existing tags
           

            //removed




            //remove tags globaly, which are not used anywhere to prevent from trashing tags table
            
           

            // 5. Save project
            if (!_crudService.Save())
                throw new Exception($"Updating entity {projectEntity.Id} failed on save.");

            return Ok();
        }

        [HttpPut("{id}")]        
        public override IActionResult Update(Guid id, [FromBody] ProjectForCreationDto entityToUpdate)
        {
            /*
            //var entityFromRepo = _crudService.Get(id, true);            
            var entityFromRepo = _crudService.Context.Set<Project>()
                .Select(p => new Project
                {
                    Id = p.Id,
                    ProjectId = p.ProjectId,
                    Title = p.Title,
                    Note = p.Note,
                    Tags = p.RelationTags.Select(t => new Tag
                    {
                        Id = t.Tag.Id,
                        Title = t.Tag.Title,
                        Level = t.Tag.Level
                    })
                }).FirstOrDefault(p => p.Id == id);

            if (entityFromRepo == null)
                return NotFound();

            Mapper.Map(entityToUpdate, entityFromRepo);

            if (!_crudService.Save())
                throw new Exception($"Updating entity {id} failed on save.");
                */
            return NoContent();
        }

        [HttpGet("tags")]
        public IActionResult GetTags()
        {
            var id = Guid.Parse("4F6D6D32-19D0-49AC-02A6-08D5E4ADDFA7");

            return Ok();            
        }
    }
}