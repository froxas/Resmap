using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class ProjectForUpdateDto
    {
        public Guid Id { get; set; }

        public string ProjectId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Manager { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public IEnumerable<TagDto> Tags { get; set; } = new List<TagDto>();
    }
}


