using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace BugTracker.Api.Controllers 
{ 
    [Route("[controller]")]
    [AllowAnonymous]
    public class TasksController : ApiController
    {
        [HttpGet]
        public IActionResult ListTasks()
        {
            return Ok(Array.Empty<string>());
        }
    }
}