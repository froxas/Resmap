using AutoMapper;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Helpers
{
    public class TagsManager
    {
        public void MapTags(
            ITagService tagService, 
            Project entityFromRepo, 
            ProjectForCreationDto entityToCreate)
        {
            var tagsFromDto = Mapper.Map<IEnumerable<Tag>>(entityToCreate.Tags);

            if (entityFromRepo.ProjectTags.Any())
            {
                var tempTags = entityFromRepo.ProjectTags.Select(t => t.Tag).ToList();
                
                var tagsForRemove = tempTags.Except(tagsFromDto).ToList();
                entityFromRepo.ProjectTags.Clear();
            }
            

            foreach (var tag in tagsFromDto)
            {
                if (tag.Id != Guid.Empty)
                {
                    entityFromRepo.ProjectTags.Add(new ProjectTag
                    {
                        TagId = tag.Id,
                        ProjectId = entityFromRepo.Id
                    });
                }
                else
                {
                    var newTag = new Tag { Title = tag.Title, Level = tag.Level };
                    tagService.Create(newTag);

                    entityFromRepo.ProjectTags.Add(new ProjectTag
                    {
                        TagId = newTag.Id,
                        ProjectId = entityFromRepo.Id
                    });
                }            
            }
        }
    }
}
