namespace Resmap.Domain
{
    public interface ITag : IBaseEntity
    {
        TagLevel Level { get; set; }
        string Title { get; set; }
    }
}