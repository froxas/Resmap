using Resmap.Domain;

namespace Resmap.Data.Services
{
    public interface IResourceService<TEntity> : IRepository<TEntity> where TEntity : IBaseEntity
    {
    }
}

