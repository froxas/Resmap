using Microsoft.EntityFrameworkCore;
using Resmap.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resmap.API.Services
{
    public class RelationService : Repository<Relation>, IRelationService
    {    
        public RelationService(ApplicationDbContext context) 
            : base(context)
        {            
        }      
    }
}
