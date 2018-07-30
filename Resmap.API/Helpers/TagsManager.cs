using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Helpers
{
    /// <summary>
    /// Helper class for to manage entity tags
    /// </summary>
    public class TagsManager
    {
        /// <summary>
        /// Method to add new tags to the entity tags collection 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityTags">Tags collection got from entity object</param>
        /// <param name="tags">Tags collection got from EntityDto object</param>
        /// <param name="entityId">Entity id which owns tags for to manage</param>
        /// <param name="_tagService">Tags service passed from controller</param>
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
