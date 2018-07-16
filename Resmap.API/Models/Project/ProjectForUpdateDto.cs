using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.API.Models
{
    public class ProjectForUpdateDto
    {
        public Guid Id { get; set; }
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}


