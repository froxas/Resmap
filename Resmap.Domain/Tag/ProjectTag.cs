using System;

namespace Resmap.Domain
{
    public class ProjectTag : BaseEntity, IJoinEntity<Project>, IJoinEntity<Tag>
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        Project IJoinEntity<Project>.Navigation
        {
            get => Project;
            set => Project = value;
        }
        
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
        Tag IJoinEntity<Tag>.Navigation
        {
            get => Tag;
            set => Tag = value;
        }
    }
}
