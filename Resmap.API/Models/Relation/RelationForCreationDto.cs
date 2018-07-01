using Resmap.Domain;
using System.ComponentModel.DataAnnotations;

namespace Resmap.API.Models
{
    public class RelationForCreationDto
    {        
        public string RelationId { get; set; }

        [Required]
        public string Title { get; set; }
                
        public RelationType RelationType { get; set; }

        public ContactDto Contact { get; set; }
        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }

        // TODO: add tags
    }
}
