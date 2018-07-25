using System;
using System.Collections.Generic;

namespace Resmap.API.Models
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        public RelationDto Client { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public IEnumerable<TagDto> Tags { get; set; }
    }
}
