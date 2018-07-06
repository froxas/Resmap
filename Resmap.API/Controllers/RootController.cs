using Microsoft.AspNetCore.Mvc;

namespace Resmap.API.Controllers
{
    [Route("/api/")]
    public class RootController : Controller
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {            
            var response = new
            {
                href = Url.Link(nameof(GetRoot), null),
                //employees = new { href = Url.Link(nameof(EmployeeController.GetEmployees), null) },
                
            };          
            
            return Ok(response);
        }
       
    }
}