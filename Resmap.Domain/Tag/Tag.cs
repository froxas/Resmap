namespace Resmap.Domain
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }
        public TagType TagType { get; set; }
        public TagLevel Level { get; set; }
    }
}
