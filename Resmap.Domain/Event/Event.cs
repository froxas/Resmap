using System;

namespace Resmap.Domain
{
    public class Event : BaseEntity
    {
        public DateTime From { get; set; }
        public DateTime Till { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
