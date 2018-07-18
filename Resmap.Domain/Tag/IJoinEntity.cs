using System;

namespace Resmap.Domain
{
    public interface IJoinEntity<T> where T : ITaggable
    {
        Guid ResourceId { get; set; }
        T Resource { get; set; }

        Guid TagId { get; set; }
        Tag Tag { get; set; }
    }
}
