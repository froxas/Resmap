using System;

namespace Resmap.API.Models
{
    public class RelationDto
    {
        public Guid Id { get; set; }
        public string RelationId { get; set; }
        public string Title { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }
    }
}
