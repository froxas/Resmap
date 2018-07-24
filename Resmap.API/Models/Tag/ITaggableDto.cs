using System.Collections.Generic;

namespace Resmap.API.Models
{
    /// <summary>
    /// ITaggableDto interface 
    /// all dto entities with tags needs to implement it
    /// in order to use TagManager
    /// </summary>
    public interface ITaggableDto
    {
        ICollection<TagDto> Tags { get; set; }
    }
}
