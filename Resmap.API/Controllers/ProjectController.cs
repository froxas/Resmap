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
            var entityFromRepo = _crudService.Get(id, true);
            if (entityFromRepo == null)
                return NotFound();

            Mapper.Map(entityToUpdate, entityFromRepo);
            
            var tags = entityToUpdate.Tags;
            entityFromRepo.Tags.Clear();
            foreach (var tag in tags)
            {
                if (tag.Id == null)
                {
                    entityFromRepo.Tags.Add(new Tag { Title=tag.Title, Level=tag.Level});
                } else
                {
                    entityFromRepo.Tags.Add(new Tag { Id=tag.Id, Title = tag.Title, Level = tag.Level });
                }      
            }


            // Do Tags Stuff


            if (!_crudService.Save())
                throw new Exception($"Updating entity {id} failed on save.");
               
            return NoContent();
        }

        [HttpGet("tags")]
        public IActionResult GetTags()
        {
            var id = Guid.Parse("01c6d88d-e80b-4b67-8f71-08d5e4320ae4");
            var entityFromRepo = _crudService.Get(id, true);

            entityFromRepo.Tags.Add(new Tag { Title="QA", Level=TagLevel.Level2});
            _crudService.Save();

            return Ok();            
        }
    }
}