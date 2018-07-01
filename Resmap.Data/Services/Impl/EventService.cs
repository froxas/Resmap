using Microsoft.EntityFrameworkCore;
using Resmap.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.Data.Services
{
    public class EventService<TEntity> : Repository<TEntity>, IEventService<TEntity> where TEntity : Event
    {
        public EventService(ApplicationDbContext context)
            : base(context)
        {
        }

        public IEnumerable<TEntity> GetResources()
        {
            return Context.Set<TEntity>().ToList();
        }
    }  
}
