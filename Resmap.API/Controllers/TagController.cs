using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;

namespace Resmap.API.Controllers
{
    [Route("api/tags")]
    public class TagController : BaseCrudController<Tag, TagDto, TagDto>
    {
        public TagController(
            ICrudService<Tag> crudService) : base(crudService)
        {
        }
    }
}