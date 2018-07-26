using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class ProjectForCreationDto : ITaggableDto
    {
        public string ProjectId { get; set; }

        public string Title { get; set; }
        public string Manager { get; set; }
        
        public Guid ClientId { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public ICollection<TagDto> Tags { get; set; }
    }
}


