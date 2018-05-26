namespace Resmap.API.Models
{
    public class RelationForCreationDto
    {        
        public string RelationId { get; set; }
        public string Title { get; set; }

        public AddressDto Address { get; set; }
        public NoteDto Note { get; set; }
    }
}
