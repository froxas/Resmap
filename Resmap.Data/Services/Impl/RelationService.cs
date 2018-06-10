using Resmap.Domain;

namespace Resmap.Data.Services
{
    public class RelationService : Repository<Relation>, IRelationService
    {    
        public RelationService(ApplicationDbContext context) 
            : base(context)
        {            
        }      
    }
}
