using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Data;
using Resmap.API.Models;
using Resmap.API.Services;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/relations/collection")]
    public class RelationCollectionController : Controller
    {
        private IRelationService _relationService;

        public RelationCollectionController(IRelationService relationService)
        {
            _relationService = relationService;
        }

        [HttpPost]
        public IActionResult CreateReltionCollection(
            [FromBody] IEnumerable<RelationForCreationDto> relationCollection)
        {
            if (relationCollection == null)
            {
                return BadRequest();
            }

            var relationEntities = Mapper.Map<IEnumerable<Relation>>(relationCollection);

            foreach (var relation in relationEntities)
            {
                _relationService.Add(relation);
            }

            if (!_relationService.Save())
                throw new Exception("Creating relation failed on save.");

            return Ok();
        }

    }
}
