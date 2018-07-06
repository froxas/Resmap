using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Domain;
using System;

namespace Resmap.API.Controllers
{
    /// <summary>
    /// Generic Base controller for to manage Events 
    /// </summary>
    /// <typeparam name="TEvent">Event entity</typeparam>
    /// <typeparam name="TResource">Resource entity</typeparam>
    /// <typeparam name="TEventDto">View model for to show events</typeparam>
    /// <typeparam name="TEventForCreacteDto">View model for to create event</typeparam>
    /// <typeparam name="TResourceDto">View model for to show resources</typeparam>
    public interface IBaseEventController<TEvent, TResource, TEventDto, TEventForCreacteDto, TResourceDto>        
        where TEvent : Event
        where TResource : BaseEntity
        where TEventDto : EventDto
        where TEventForCreacteDto : EventForCreationDto
        where TResourceDto : ResourceDto
    {
        /// <summary>
        /// Returns all resources of given entty TResource
        /// </summary>
        /// <returns></returns>
        IActionResult GetResources();

        /// <summary>
        /// Returns all events of given entity TEvent 
        /// </summary>
        /// <returns></returns>
        IActionResult GetEvents();

        /// <summary>
        /// Returns event of given entity TEvent
        /// </summary>
        /// <param name="id">event id</param>
        /// <returns>response object with TEventDto view model</returns>        
        IActionResult GetEvent(Guid id);

        /// <summary>
        /// Creates event 
        /// </summary>
        /// <param name="newEvent">TEventForCreacteDto view model</param>
        /// <returns>NoContent</returns>       
        IActionResult CreateEvent([FromBody] TEventForCreacteDto newEvent);

        /// <summary>
        /// Updates event
        /// </summary>
        /// <param name="id">Id of event for to update</param>
        /// <param name="eventToUpdate">TEventForCreacteDto view model</param>
        /// <returns>NoContent</returns>        
        IActionResult UpdateEvent(Guid id, [FromBody] TEventForCreacteDto eventToUpdate);

        /// <summary>
        /// Deletes event
        /// </summary>
        /// <param name="id"></param>
        /// <returns>NoContent</returns>        
        IActionResult DeleteEvent(Guid id);
    }
}
