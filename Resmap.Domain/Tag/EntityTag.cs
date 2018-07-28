using System;

namespace Resmap.Domain
{
    public interface IEntityTag
    {
        Guid TagId { set; get; }
        Guid EntityId { set; get; }
    }
}
