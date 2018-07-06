using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Controllers.Infrastructure;
using Resmap.API.Models;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{   
    public class BaseEventController<TEvent, TResource, TEventDto, TEventForCreacteDto, TResourceDto> 
        : Controller, IBaseEventController<TEvent, TResource, TEventDto, TEventForCreacteDto, TResourceDto>
        where TEvent : Event
        where TResource : BaseEntity
        where TEventDto : EventDto
        where TEventForCreacteDto: EventForCreationDto
        where TResourceDto : ResourceDto
    {
        private readonly IEventService<TEvent> _eventService;
        private readonly IRepository<TResource> _resourceService;

        public BaseEventController(
            IEventService<TEvent> eventService,
            IRepository<TResource> resourceService
            )
        {
            _eventService = eventService;
            _resourceService = resourceService;            
        }        
        
        [HttpGet("resources")]
        public IActionResult GetResources()
        {
            var resourcesFromRepo = _resourceService.Get(true);
            var response = Mapper.Map<IEnumerable<TResourceDto>>(resourcesFromRepo);
            var responseObject = new { resources = response };

            return Ok(responseObject);
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var eventsFromRepo = _eventService.Get();
            var response = Mapper.Map<IEnumerable<TEventDto>>(eventsFromRepo);
            var responseObject = new { events = response };

            return Ok(responseObject);
        }               
      
        [HttpGet("{id}")]
        public IActionResult GetEvent(Guid id)
        {
            var eventFromRepo = _eventService.Get(id);

            if (eventFromRepo == null)
                return NotFound();
           
            var response = Mapper.Map<TEventDto>(eventFromRepo);
            
            return Ok(response);
        }
      
        [HttpPost()]
        [ValidateModel]
        public IActionResult CreateEvent([FromBody] TEventForCreacteDto eventToCreate)
        {
            var eventEntity = Mapper.Map<TEventForCreacteDto, TEvent>(eventToCreate);
            _eventService.Create(eventEntity);

            if (!_eventService.Save())
                throw new Exception("Creating event failed on save.");

            var eventToTeturn = Mapper.Map<EventDto>(eventEntity);

            return NoContent();            
        }
       
        [HttpPut("{id}")]
        [ValidateModel]
        public IActionResult UpdateEvent(Guid id, [FromBody] TEventForCreacteDto eventToUpdate)
        {
            var eventFromRepo = _eventService.Get(id);

            if (eventFromRepo == null)
                return NotFound();

            Mapper.Map(eventToUpdate, eventFromRepo);

            if (!_eventService.Save())
                throw new Exception($"Updating event {id} failed on save.");

            return NoContent();
        }
       
        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(Guid id)
        {
            var eventFromRepo = _eventService.Get(id);

            if (eventFromRepo == null)
                return NotFound();

            _eventService.Delete(eventFromRepo);
            if (!_eventService.Save())
                throw new Exception($"Deleting event {id} failed on save.");

            return NoContent();
        }
    }
}
