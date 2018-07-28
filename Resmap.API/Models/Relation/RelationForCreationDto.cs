using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class RelationForCreationDto: ITaggableDto
    {
        public Guid? Id { get; set; }
        public string RelationId { get; set; }

        [Required]
        public string Title { get; set; }
                
        public RelationType RelationType { get; set; }

        public ContactDto Contact { get; set; }
        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        public ICollection<TagDto> Tags { get; set; } = new List<TagDto>();       
    }



}
