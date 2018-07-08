using System.Collections.Generic;
using System.Linq;
using Resmap.Domain;

namespace Resmap.Data.Services
{ 
    public class TagService : Repository<Tag>, ITagService
    {
        public TagService(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<Tag> Manage(IEnumerable<Tag> tagsFromDto, IEnumerable<Tag> tagsFromEntity)
        {
            if (tagsFromDto.SequenceEqual(tagsFromEntity))
            {
                return tagsFromDto;
            }

            if (tagsFromDto.Any(e => e.Id == null))
            {
                foreach (var tag in tagsFromDto.Where(t => t.Id == null))
                {
                    Context.Set<Tag>().Add(tag);
                    Context.SaveChanges();
                }                
            }

            return null;            
        }
    }
}

