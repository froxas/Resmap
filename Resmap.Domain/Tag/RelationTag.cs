using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{   
    public class RelationTag : BaseEntity, IEntityTag
    {
        public Guid RelationId { get; set; }
        public Relation Relation { get; set; }

        [NotMapped]
        public Guid EntityId { get => RelationId; set => RelationId = value; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
