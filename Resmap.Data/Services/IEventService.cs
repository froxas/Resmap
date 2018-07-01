using Resmap.Domain;
using System.Collections.Generic;

namespace Resmap.Data.Services
{
    public interface IEventService<TEntity> : IRepository<TEntity> where TEntity : Event
    {        
    }
}
