using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class EventService : Repository<Event>, IEventService
    {
        public EventService(ApplicationDbContext context)
           : base(context)
        {
        }
    }
}
