using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{
    /// <summary>
    /// ITaggable interface 
    /// all entities with tags needs to implement it
    /// </summary>
    public interface ITaggable
    {
        [NotMapped]
        ICollection<Tag> Tags { get; }
    }
}
