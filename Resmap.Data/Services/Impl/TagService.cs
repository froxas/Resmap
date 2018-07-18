using System;
using System.Collections.Generic;
using System.Linq;
using Resmap.Domain;

namespace Resmap.Data.Services
{ 
    public class TagService<T, TJoin> : Repository<Tag>, ITagService<T, TJoin>
        where T : ITaggable
        where TJoin : JoinEntity<T>, new()
    {
        public TagService(ApplicationDbContext context)
            : base(context)
        {
        }

        public ICollection<TJoin> GetMappedTags(
            Guid projectId,
            IEnumerable<Tag> tags,
            ICollection<TJoin> projectTags)
        {
            if (projectTags.Any())
            {
                var tempTags = projectTags.Select(t => t.Tag).ToList();
                var tagsForRemove = tempTags.Except(tags).ToList();
                projectTags.Clear();
            }

            foreach (var tag in tags)
            {
                if (tag.Id != Guid.Empty)
                {
                    projectTags.Add(new TJoin
                    {                        
                        TagId = tag.Id,
                        ResourceId = projectId
                    });
                }
                else
                {
                    var newTag = new Tag { Title = tag.Title, Level = tag.Level };
                    Create(newTag);
                    
                    projectTags.Add(new TJoin
                    {
                        TagId = newTag.Id,
                        ResourceId = projectId
                    });
                }
            }            

            return projectTags;
        }
        
    }
}

