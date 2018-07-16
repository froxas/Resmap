using System.Collections.Generic;
using System.Linq;
using Resmap.Domain;

namespace Resmap.Data.Services
{ 
    public class TagService<T> : Repository<Tag>, ITagService<T> where T : ITaggable  
    {
        public TagService(ApplicationDbContext context)
            : base(context)
        {
        }

        public void MapTags(T OldEntity, T UpdatedEntity)
        {
            var tagsToRemove = OldEntity.Tags.Except(UpdatedEntity.Tags);
            //RemoveTags(tagsToRemove);

            OldEntity.Tags.Clear();

            foreach (var tag in UpdatedEntity.Tags)
                OldEntity.Tags.Add(tag);
        }

        private void RemoveTags(IEnumerable<Tag> tagsToRemove)
        {
            
        }

    }
}

