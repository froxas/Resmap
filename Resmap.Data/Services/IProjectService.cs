using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resmap.Data.Services
{
    public interface IProjectService<TEntity> : IRepository<TEntity> where TEntity : IBaseEntity
    {
    }
}
