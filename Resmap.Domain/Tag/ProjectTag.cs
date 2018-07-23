using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{  
    public class ProjectTag : BaseEntity, IEntityTag
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
       
        [NotMapped]
        public Guid EntityId { get => ProjectId; set => ProjectId = value; }
        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
