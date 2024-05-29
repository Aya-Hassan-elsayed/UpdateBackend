using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Zezo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> getdata()
        {
            string c = "1235456";

            // Await an asynchronous operation, for example, Task.Delay
            await Task.Delay(100); // This is just a placeholder, replace it with your actual asynchronous operation

            // Now, you can return the string
            return Ok(c);
        }
    }
}
