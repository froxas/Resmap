using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface ITagService : IRepository<Tag>                
        
    {
        /// <summary>
        /// Get mapped tags collection
        /// </summary>
        /// <param name="ProjectId">project id</param>
        /// <param name="tags">collection of tags from Dto</param>
        /// <param name="projectTags">collection of tags to be mapped</param>        
        /// <returns>collection of mapped tags to return</returns>
        ICollection<ProjectTag> GetMappedTags(
            Guid projectId,
            IEnumerable<Tag> tags,
            ICollection<ProjectTag> projectTags);
    }
}
