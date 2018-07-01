using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.Data.Services;
using Resmap.Domain;

namespace Resmap.API.Controllers
{
    public class BaseCrudController<TEntity, TEntityDto> : Controller
        where TEntity : BaseEntity
        where TEntityDto : class
    {
        private readonly ICrudService<TEntity> _crudService;

        public BaseCrudController(ICrudService<TEntity> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var entityFromRepo = _crudService.GetAll(true);
            var response = Mapper.Map<IEnumerable<TEntityDto>>(entityFromRepo);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var entityFromRepo = _crudService.Get(id, true);

            if (entityFromRepo == null)
                return NotFound();

            var response = Mapper.Map<TEntityDto>(entityFromRepo);

            return Ok(response);
        }
    }
}