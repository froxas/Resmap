using Resmap.Domain;

namespace Resmap.Data.Services
{
    public interface ICrudService<TEntity> : IRepository<TEntity> where TEntity : IBaseEntity
    {
    }
}
