using System;
using System.ComponentModel.DataAnnotations;

namespace Resmap.Domain
{
    /// <summary>
    /// The base class starting point for events
    /// all event entities needs to inheritate it in order to use IEventManager
    /// </summary>
    public abstract class Event : BaseEntity, IEvent
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public Guid Resource { get; set; }
    }
}
