using System;

namespace Resmap.API.Data
{
    public class Event : BaseEntity
    {
        public Milestone Milestone { get; set; }
        public Guid ResourceId { get; set; }
    }
}
