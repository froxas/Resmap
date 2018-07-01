using System;
using System.Collections.Generic;

namespace Resmap.Domain
{
    public class EventsResponseObject
    {
        public IEnumerable<Object> Resources { get; set; }
        public IEnumerable<Object> Events { get; set; }
    }
}
