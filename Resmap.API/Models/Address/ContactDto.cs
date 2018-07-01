using System;

namespace Resmap.API.Models
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
