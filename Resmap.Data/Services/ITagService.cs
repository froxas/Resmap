using Resmap.Domain;
using System;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface ITagService<T, TJoin> : IRepository<Tag>        
        where T : ITaggable
        where TJoin : JoinEntity<T>, new()       
    {
        /// <summary>
        /// Get mapped tags collection
        /// </summary>
        /// <param name="ProjectId">project id</param>
        /// <param name="tags">collection of tags from Dto</param>
        /// <param name="projectTags">collection of tags to be mapped</param>        
        /// <returns>collection of mapped tags to return</returns>
        ICollection<TJoin> GetMappedTags(
            Guid projectId,
            IEnumerable<Tag> tags,
            ICollection<TJoin> projectTags);
    }
}
