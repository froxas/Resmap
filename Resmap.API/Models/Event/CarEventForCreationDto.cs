using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class CarEventForCreationDto
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public Guid Resource { get; set; }

        public Guid? EmployeeId { get; set; }
    }
}
