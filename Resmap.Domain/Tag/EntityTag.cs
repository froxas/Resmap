using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resmap.Domain
{
    public interface IEntityTag
    {
        Guid TagId { set; get; }
        Guid EntityId { set; get; }
    }
}
