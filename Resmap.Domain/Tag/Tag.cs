using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Resmap.Domain
{
    public class Tag : BaseEntity
    {
        public Tag() 
            => Projects = new JoinCollectionFacade<Project, Tag, ProjectTag>(this, ProjectTags);         

        public string Title { get; set; }
        public TagType TagType { get; set; }
        public TagLevel Level { get; set; }

        private ICollection<ProjectTag> ProjectTags { get; } = new List<ProjectTag>();

        [NotMapped]
        public IEnumerable<Project> Projects { get; }
    }
}
