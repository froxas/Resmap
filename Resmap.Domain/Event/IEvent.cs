using System;

namespace Resmap.Domain
{
    public interface IEvent
    {
        /// <summary>
        /// Event text, shows on an event bar
        /// </summary>
        //string Text { get; set; }

        /// <summary>
        /// Event starting date
        /// </summary>
        DateTime Start { get; set; }

        /// <summary>
        /// Event end date
        /// </summary>
        DateTime End { get; set; }

        /// <summary>
        /// Navigation property to resource id
        /// </summary>
        Guid Resource { get; set; }
    }
}
