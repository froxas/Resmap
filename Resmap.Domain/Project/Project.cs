namespace Resmap.Domain
{
    public class Project : BaseEntity
    {
        public string ProjectId { get; set; }
        public string Title { get; set; }
        public string Manager { get; set; }        
    }
}
