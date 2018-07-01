using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class RelationService : Repository<Relation>, IRelationService
    {    
        public RelationService(ApplicationDbContext context) 
            : base(context)
        {            
        }
        
        public IEnumerable<Relation> AllRelationsALlIncluded()
        {
            var relations = Context.Set<Relation>()
                .Include(c => c.Contact)
                .Include(a => a.Address)
                .Include(n => n.Note)
                .Include(rt => rt.RelationTags)
                .ThenInclude(t => t.Tag)
                .ToList();

            return relations;
        }

        public Relation GetByIdAllIncluded(Guid id)
        {
            var relation = Context.Set<Relation>()
                
                .Include(c => c.Contact)
                .Include(a => a.Address)
                .Include(n => n.Note)
                .Include(rt => rt.RelationTags)
                .ThenInclude(t => t.Tag)
                .FirstOrDefault(r => r.Id == id);

            return relation;
        }
            

        public IEnumerable<Relation> GetRelationsAllIncluded() 
            => GetAllIncludes(
                c => c.Contact,
                a => a.Address,
                n => n.Note);

        public IEnumerable<Relation> GetAllWithTags()
            => GetAllIncludes(
                c => c.Contact,
                a => a.Address,
                n => n.Note)                
                .Include(r => r.RelationTags).
                ThenInclude(t => t.Tag);     
        
    }
}
