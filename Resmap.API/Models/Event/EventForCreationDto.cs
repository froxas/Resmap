using System;

namespace Resmap.API.Models
{
    public class EventForCreationDto
    {   
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Guid Resource { get; set; }        
    }
}
