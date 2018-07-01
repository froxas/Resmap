using Microsoft.AspNetCore.Mvc;
using Resmap.API.Models;
using Resmap.Data.Services;
using Resmap.Domain;

namespace Resmap.API.Controllers
{
    [Route("/")]
    public class TestBaseCrudController : BaseCrudController<Employee, EmployeeDto>
    {
        public TestBaseCrudController(
            ICrudService<Employee> crudService) 
            : base(crudService)
        {
        }               
    }
}