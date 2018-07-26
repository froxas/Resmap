using System;

namespace Resmap.API.Models
{
    public class CarEventForCreationDto : EventForCreationDto
    {
        public Guid? Id { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
