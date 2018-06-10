using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        private IEventService _eventService;
        private IEmployeeService _employeeService;

        public EventsController(IEventService eventService, IEmployeeService employeeService)
        {
            _eventService = eventService;
            _employeeService = employeeService;
        }

        [HttpGet(Name = nameof(GetEvents))]
        public IActionResult GetEvents()
        {
            var eventsFromRepo = _eventService.GetAll();         
            var events = Mapper.Map<ICollection<EventDto>>(eventsFromRepo);

            var employeesFromRepo = _employeeService.GetAll();
            var employees = Mapper.Map<ICollection<EmployeeDto>>(employeesFromRepo);

            var response = new ResponseObject
            {
                Resources = employees,
                Events = events
            };

            return Ok(response);
        }

        class ResponseObject
        {
            public ICollection<EmployeeDto> Resources { get; set; }
            public ICollection<EventDto> Events { get; set; }
        }
    }
}