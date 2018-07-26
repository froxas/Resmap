using System;
using System.Collections.Generic;
using System.Linq;
using Resmap.Domain;

namespace Resmap.Data.Services
{ 
    public class TagService : Repository<Tag>, ITagService
        
    {
        public TagService(ApplicationDbContext context)
            : base(context)
        {
        }

        public ICollection<ProjectTag> GetMappedTags(
            Guid projectId,
            IEnumerable<Tag> tags,
            ICollection<ProjectTag> projectTags)
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
                    projectTags.Add(new ProjectTag
                    {                        
                        TagId = tag.Id,
                        ProjectId = projectId
                    });
                }
                else
                {
                    var newTag = new Tag { Title = tag.Title, Level = tag.Level };
                    Create(newTag);
                    
                    projectTags.Add(new ProjectTag
                    {
                        TagId = newTag.Id,
                        ProjectId = projectId
                    });
                }
            }            

            return projectTags;
        }
        
    }
}

