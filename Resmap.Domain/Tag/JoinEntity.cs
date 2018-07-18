using System;

namespace Resmap.Domain
{
    public class JoinEntity<T> : BaseEntity where T : ITaggable
    {
        public Guid ResourceId { get; set; }
        public T Resource { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
