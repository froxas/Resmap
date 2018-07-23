using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Helpers
{
    public class TagsMapper
    {
        private readonly ITagService _tagService;

        private ICollection<ITag> NewTags { get; set; }
        private ICollection<ITag> OldTags { get; set; }
        private ICollection<ITag> MappedTags { get; set; } = new List<ITag>();
        public ICollection<ITag> TagsToRemove { get; set; } = new List<ITag>();

        public TagsMapper(
            ICollection<ITag> newTags, 
            ICollection<ITag> oldTags, 
            ITagService tagService)
        {
            NewTags = newTags;
            OldTags = oldTags;
            _tagService = tagService;
        }

        public ICollection<ITag> GetMappedTags()
        {
            if (OldTags.Any())
            {
                TagsToRemove = OldTags.Except(NewTags).ToList();              
            }

            foreach (var tag in NewTags)
            {
                if (tag.Id != Guid.Empty)
                {
                    MappedTags.Add(new Tag { Id = tag.Id, Title = tag.Title, Level = tag.Level});
                }
                else
                {                    
                    _tagService.Create( new Tag { Title = tag.Title, Level = tag.Level});
                    MappedTags.Add(new Tag { Title = tag.Title, Level = tag.Level });
                }
            }

            return MappedTags;
        } 
        
        public void RemoveUnusedTags()
        {
            foreach (var tag in TagsToRemove)
            {
                if (true)
                {
                   // _tagService.Delete(tag);
                }
            }
        }       
    }
}
