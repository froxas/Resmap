using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Controllers
{
    [Route("api/events/car")]
    public class CarEventController :
          BaseEventController<
              CarEvent,
              Car,
              CarEventDto,
              CarEventForCreationDto,
              ResourceCarDto
              >
    {
        public CarEventController(
            IEventService<CarEvent> eventService,
            IResourceService<Car> resourceService)
            : base(eventService, resourceService)
        {
        }

    }
}
