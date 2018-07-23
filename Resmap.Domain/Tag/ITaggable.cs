using System.Collections.Generic;

namespace Resmap.Domain
{
    /// <summary>
    /// ITaggable interface 
    /// all entities with tags needs to implement it
    /// in order to use TagService GetMappedTags()
    /// </summary>
    public interface ITaggable<T> where T : IEntityTag        
    {
        ICollection<T> Tags { get; set; }
    }
}
