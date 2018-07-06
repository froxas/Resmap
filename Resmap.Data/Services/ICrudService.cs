using Resmap.Domain;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.Data.Services
{
    public interface ICrudService<TEntity> : IRepository<TEntity> where TEntity : IBaseEntity
    {
               


    }

    

}
