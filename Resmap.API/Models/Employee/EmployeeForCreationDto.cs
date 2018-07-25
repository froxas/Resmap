using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class EmployeeForCreationDto
    {        
        public string EmployeeID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public JobTitleDto JobTitle { get; set; }

        public string Department { get; set; }

        [Required]
        public bool IsSubcontractor { get; set; }

        public AddressDto Address { get; set; }
        public ContactDto Contact { get; set; }
        public NoteDto Note { get; set; }
    }
}

