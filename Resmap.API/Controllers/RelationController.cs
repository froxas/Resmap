using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;

namespace Resmap.API.Controllers
{
    [Route("api/relations")]
    public class RelationController : BaseCrudTagController<
        Relation, 
        RelationDto, 
        RelationForCreationDto,        
        RelationTag
        >
    {
        public RelationController(
            ITagService tagService,
            ICrudService<Relation> crudService) : base("Tags.Tag", tagService, crudService)
        {
        }
    }
}