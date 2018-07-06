using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Resmap.Domain
{
    public class Project : BaseEntity, ITaggable
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        public Note Note { get; set; }
               
        public ICollection<ProjectTag> ProjectTags { get; set; }

        [NotMapped]
        public IEnumerable<Tag> Tags { get; set; }
    }
}
