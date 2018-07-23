using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class ProjectForCreationDto : ITaggableDto
    {
        public string ProjectId { get; set; }

        [Required]
        public string Title { get; set; }
        public string Manager { get; set; }

        public AddressForCreationDto Address { get; set; }
        public NoteDto Note { get; set; }

        public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();

    }
}


