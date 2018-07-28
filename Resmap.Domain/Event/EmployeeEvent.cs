using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{    
    public class EmployeeEvent : Event
    {
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
