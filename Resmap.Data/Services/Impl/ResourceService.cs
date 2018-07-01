using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class ResourceService<TEntity> : Repository<TEntity>, IResourceService<TEntity> where TEntity : BaseEntity
    {
        public ResourceService(ApplicationDbContext context)
          : base(context)
        {
        }
    }
}
