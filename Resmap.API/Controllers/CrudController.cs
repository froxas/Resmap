using Microsoft.AspNetCore.Mvc;
using Resmap.API.Data;

namespace Resmap.API.Controllers
{
    [Route("api/[controller]")]
    public class CrudController<T> : Controller where T : class
    {
        private IRepository<T> _repository;

        public CrudController(IRepository<T> repository) => _repository = repository;

        [HttpGet]
        public IActionResult GetAll()
        {
            //var userFromRepos = _repository.GetAll();
            //var users = Mapper.Map<IEnumerable<UserDto>>(userFromRepos);
            return Ok(_repository.GetAll());
        }
    }
}