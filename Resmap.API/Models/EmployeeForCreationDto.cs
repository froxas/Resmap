namespace Resmap.API.Models
{
    public class EmployeeForCreationDto
    {
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public bool IsSubcontractor { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }
    }
}

