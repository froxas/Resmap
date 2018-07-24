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
            ICrudService<Project> crudService) : base("Tags.Tag", tagService, crudService)
        {     
        }               
    }    
}