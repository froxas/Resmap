using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{
    public class Project : BaseEntity, ITaggable
    {
        public Project()
            => Tags = new JoinCollectionFacade<Tag, ProjectTag>(
                ProjectTags,
                pt => pt.Tag,
                t => new ProjectTag { Project = this, Tag = t });        
         
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        public Address Address { get; set; }
        public Note Note { get; set; }

        private ICollection<ProjectTag> ProjectTags { get; } = new List<ProjectTag>();

        [NotMapped]
        public ICollection<Tag> Tags { get; }
    }
}
