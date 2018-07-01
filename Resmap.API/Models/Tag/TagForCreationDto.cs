using Resmap.Domain;

namespace Resmap.API.Models
{ 
    public class TagForCreationDto
    {
        public string Title { get; set; }
        public TagType TagType { get; set; }
    }
}
