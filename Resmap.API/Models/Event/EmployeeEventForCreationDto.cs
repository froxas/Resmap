using System;

namespace Resmap.API.Models
{
    public class EmployeeEventForCreationDto : EventForCreationDto
    {
        public Guid? Id { get; set; }        
        public Guid? ProjectId { get; set; }
    }
}
