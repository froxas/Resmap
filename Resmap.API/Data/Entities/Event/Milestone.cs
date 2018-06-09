using System;

namespace Resmap.API.Data
{
    public class Milestone : BaseEntity
    {
        public DateTime From { get; set; }
        public DateTime Till { get; set; }
    }
}
