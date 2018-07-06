using Microsoft.EntityFrameworkCore;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Resmap.Data.Services
{
    public class CrudService<TEntity> : Repository<TEntity>, ICrudService<TEntity> where TEntity : BaseEntity
    {
        public CrudService(ApplicationDbContext context)
            : base(context)
        {
        }
             
    }
}

