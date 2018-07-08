using Resmap.Domain;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface ITagService : IRepository<Tag>
    {
        IEnumerable<Tag> Manage(IEnumerable<Tag> tagsFromDto, IEnumerable<Tag> tagsFromEntity);
    }
}
