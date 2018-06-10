using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/relations")]
    public class RelationController : Controller
    {
        private IRelationService _relationService;

        public RelationController(IRelationService relationService) 
            => _relationService = relationService;        

        [HttpGet(Name = nameof(GetRelations))]
        public IActionResult GetRelations()
        {            
            var relationsFromRepo = _relationService.GetAllIncludes(r => r.Address, n => n.Note);            
            var relations = Mapper.Map<IEnumerable<RelationDto>>(relationsFromRepo);
            return Ok(relations);
        }

        [HttpGet("{id}", Name = nameof(GetRelation))]
        public IActionResult GetRelation(Guid id)
        {
            var relationFromRepo = _relationService.GetById(i => i.Id == id, r => r.Address, n => n.Note);

            if (relationFromRepo == null)
                return NotFound();            
            else
            {
                var relation = Mapper.Map<RelationDto>(relationFromRepo);
                return Ok(relation);
            }
        }
       
        [HttpPost]
        public IActionResult CreateRelation([FromBody] RelationForCreationDto relation)
        {
            if (relation == null)
                return BadRequest();            

            var relationEntity = Mapper.Map<RelationForCreationDto, Relation>(relation);

            _relationService.Add(relationEntity);

            if (!_relationService.Save())            
                throw new Exception("Creating relation failed on save.");            

            var relationToReturn = Mapper.Map<RelationDto>(relationEntity);

            return CreatedAtRoute("GetRelation", 
                new { id = relationToReturn.Id}, relationToReturn);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRelation(Guid id)
        {
            var resourceFromRepo = _relationService.Get(id);

            if (resourceFromRepo == null)            
                return NotFound();            

            _relationService.Delete(resourceFromRepo);
            if (!_relationService.Save())
                throw new Exception($"Deleting relation {id} failed on save.");

            return NoContent();
        }            
    }
}