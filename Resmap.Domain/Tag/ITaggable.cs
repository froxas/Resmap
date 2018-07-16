using System.Collections.Generic;

namespace Resmap.Domain
{
    /// <summary>
    /// ITaggable interface 
    /// all entities with tags needs to implement it
    /// </summary>
    public interface ITaggable
    {        
        ICollection<Tag> Tags { get; }
    }
}
