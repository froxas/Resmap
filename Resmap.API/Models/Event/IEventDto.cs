namespace Resmap.API.Models
{
    public interface IEventDto
    {
        string Id { get; set; }       
        string Start { get; set; }
        string End { get; set; }
        string Resource { get; set; }
        string Text { get; set; }
    }
}
