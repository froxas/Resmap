using System;

namespace Resmap.API.Models
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public Guid Resource { get; set; }        
    }
}
