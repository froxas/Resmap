using System;

namespace Resmap.API.Models
{
    public class EmployeeForCreationDto
    {
        public Guid? Id { get; set; }
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public Guid? JobTitleId { get; set; }
        public Guid? DepartmentId { get; set; }
        
        public bool IsSubcontractor { get; set; }
        public Guid? SubcontractorId { get; set; }

        public AddressDto Address { get; set; }
        public ContactDto Contact { get; set; }
        public NoteDto Note { get; set; }
    }
}

