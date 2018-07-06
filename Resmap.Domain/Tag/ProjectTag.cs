using System;

namespace Resmap.Domain
{
    public class ProjectTag : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }        
    }
}
