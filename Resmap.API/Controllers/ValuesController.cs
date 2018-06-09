using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Resmap.API.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Resmap.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// The scoped application context
        /// </summary>
        protected ApplicationDbContext _context;

        /// <summary>
        /// The manager for handling users creation, deletion 
        /// </summary>
        protected UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// The manager for handling signing in and out for our users
        /// </summary>
        protected SignInManager<ApplicationUser> _signInManager;

        public ValuesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //var user = HttpContext.User.Identity.Name;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Creates our single user for now
        /// </summary>
        /// <returns></returns>
        [Route("create")]
        public async Task<IActionResult> CreateUserAsync()
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "vaidas",
                Email = "vaidas@opit.lt"
            }, "password");

            if (result.Succeeded)
                return Content("User was created", "text/html");

            return Content("User creation failed", "text/html");
        }
                
        [Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            return Content(
                $"This is private area. Welcome " +
                $"{userId}", "text/html");
        }

        [Route("logout")]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            return Content("done");
        }

        /// <summary>
        /// An auto-login page for testing
        /// </summary>
        /// <param name="returnUrl">The url to return successfully logged in</param>
        /// <returns></returns>
        [Route("login")]
        public async Task<IActionResult> LoginAsync(string returnUrl)
        {
            // Sign out any previous sessions
            await HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme);

            var result = await _signInManager.PasswordSignInAsync("vaidas", "password", true, false);

            // If successfull...
            if (result.Succeeded)
            {
                // if we have no return URL
                if (string.IsNullOrEmpty(returnUrl))
                {
                    // Go to home
                    return RedirectToAction(nameof(Get));
                }
                    // Otherwise go to return url
                    return Redirect(returnUrl);
            }

            return Content("Failed to login", "text/html");
        }
    }
}
