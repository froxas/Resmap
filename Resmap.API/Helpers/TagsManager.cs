using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resmap.API.Helpers
{
    public class TagsManager
    {
        public static void AddTags<T>(
            ICollection<T> entitytags,
            ICollection<Tag> tags,
            Guid entityId,
            ITagService _tagService)
            where T : IEntityTag, new()
        {
            foreach (var tag in tags)
            {
                if (tag.Id == Guid.Empty)
                    _tagService.Create(tag);
                entitytags.Add(new T
                {
                    TagId = tag.Id,
                    EntityId = entityId
                });
            }
        }
    }
}
