namespace Resmap.API.Models
{
    public class EventDto : IEventDto
    {
        public string Id { get; set; }        
        public string Start { get; set; }
        public string End { get; set; }
        public string Resource { get; set; }
        public string Text { get; set; }
    }
}
