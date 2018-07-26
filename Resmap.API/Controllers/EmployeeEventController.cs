using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;

namespace Resmap.API.Controllers
{
    [Route("api/events/employee")]
    public class EmployeeEventController :
          BaseEventController<
              EmployeeEvent,
              Employee,
              EmployeeEventDto,
              EmployeeEventForCreationDto,
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