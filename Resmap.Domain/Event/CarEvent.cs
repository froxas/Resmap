using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{    
    public class CarEvent : Event
    {
        [ForeignKey("Employee")]
        public Guid? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
