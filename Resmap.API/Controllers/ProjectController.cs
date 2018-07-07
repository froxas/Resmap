using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class ProjectController : BaseCrudController<Project, ProjectDto, ProjectForCreation>
    {
        private readonly IProjectService _projectService;

        public ProjectController(
            IProjectService projectService,
            ICrudService<Project> crudService) : base(crudService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public override IActionResult Get()
        {
            var entityFromRepo = _projectService.Get(true);
            var response = Mapper.Map<IEnumerable<ProjectDto>>(entityFromRepo);

            return Ok(response);            
        }

        [HttpGet("{id}")]
        public override IActionResult Get(Guid id)
        {
            /*
            var entityFromRepo =
                _crudService.Context.Set<Project>()
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

            var response = Mapper.Map<ProjectDto>(entityFromRepo);
            */
            return Ok();
        }

        [HttpPut("{id}")]        
        public override IActionResult Update(Guid id, [FromBody] ProjectForCreation entityToUpdate)
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
            var id = Guid.Parse("2C0D1788-FF24-47A7-957A-CE870F0B7CCA");

           return Ok();            
        }
    }
}