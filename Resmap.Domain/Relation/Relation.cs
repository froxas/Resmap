using System.Collections.Generic;

namespace Resmap.Domain
{
    public class Relation : BaseEntity, ITaggable<RelationTag>
    {        
        public RelationType RelationType { get; set; }
        public string RelationId { get; set; }               
        public string Title { get; set; }       

        public Contact Contact { get; set; }
        public Address Address { get; set; }              
        public Note Note { get; set; }

        public ICollection<RelationTag> Tags { get; set; } = new List<RelationTag>();
    }
}
