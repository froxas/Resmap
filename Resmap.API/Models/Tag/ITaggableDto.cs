using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resmap.API.Models
{
    public interface ITaggableDto
    {
        ICollection<TagDto> Tags { get; set; }
    }
}
