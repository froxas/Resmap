using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{
    public class Project : BaseEntity
    {           
         
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        public Address Address { get; set; }
        public Note Note { get; set; }

        public ICollection<ProjectTag> ProjectTags { get; set; }


    }
}
