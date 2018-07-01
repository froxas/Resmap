using System;

namespace Resmap.API.Models
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Flat { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
