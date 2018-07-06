using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data;
using Resmap.Data.Services;
using Resmap.Domain;

namespace Resmap.API.Controllers
{
    [Route("api/relations")]
    public class RelationController : BaseCrudController<Relation, RelationDto, RelationForCreationDto>
    {
        public RelationController(
            ICrudService<Relation> crudService) : base(crudService)
        {
        }  
    }
}