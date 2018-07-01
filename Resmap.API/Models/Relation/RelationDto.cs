using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Models
{
    public class RelationDto
    {
        public Guid Id { get; set; }
        public string RelationId { get; set; }
                
        public string Title { get; set; }
        public RelationType RelationType { get; set; }

        public ContactDto Contact { get; set; }
        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public ICollection<RelationTagDto> RelationTags { get; set; }
    }
}
