using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Helpers
{
    public class TagsManager
    {
        public static void AddTags<T>(
            ICollection<T> entityTags,
            ICollection<Tag> tags,
            Guid entityId,
            ITagService _tagService)
            where T : IEntityTag, new()
        {
            if (entityTags.Any())
            {
                var tagsToRemove = entityTags.OfType<Tag>().Except(tags).ToList();
                entityTags.Clear();
                RemoveUnusedTags();
            }

            if (tags != null)
            {
                foreach (var tag in tags)
                {

                    if (tag.Id == Guid.Empty)
                        _tagService.Create(tag);
                    entityTags.Add(new T
                    {
                        TagId = tag.Id,
                        EntityId = entityId
                    });
                }
            }
        }

        private static void RemoveUnusedTags()
        {
            // do stuff to remove unused tags
            // or return unused tags to controller
            return;
        }
    }
}
