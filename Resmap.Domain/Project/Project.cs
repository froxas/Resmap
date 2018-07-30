using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{
    public class Project : BaseEntity, ITaggable<ProjectTag>
    {        
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }

        [ForeignKey("Relation")]
        public Guid ClientId { get; set; }
        public Relation Client { get; set; }       

        public Address Address { get; set; }
        public Note Note { get; set; }

        public ICollection<ProjectTag> Tags { get; set; } = new List<ProjectTag>();
    }
       
}
