using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/events/employee")]
    public class EmployeeEventController :
          BaseEventController<
              EmployeeEvent,
              Employee,
              EmployeeEventDto,
              EventForCreationDto,
              ResourceEmployeeDto
              >
    {
        public EmployeeEventController(
            IEventService<EmployeeEvent> eventService,
            IResourceService<Employee> resourceService)
            : base(eventService, resourceService)
        {
        }

    }
}