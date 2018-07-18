namespace Resmap.Domain
{
    public class Tag : BaseEntity
    {
        public string Title { get; set; }
        public TagType TagType { get; set; }
        public TagLevel Level { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Tag item))
                return false;
            return Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
