using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class TagService : Repository<Tag>, ITagService
        
    {
        public TagService(ApplicationDbContext context)
            : base(context)
        {
        }
        
    }
}

