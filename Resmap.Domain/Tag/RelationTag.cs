using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.Domain
{
    public class RelationTag : BaseEntity
    {        
        public Guid RelationId { get; set; }
        public Relation Relation { get; set; }
          
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
