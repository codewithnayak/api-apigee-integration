namespace NotesManager.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    [Route("api/Notes")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            var values = new List<string>
           {
               "somevalue1" ,
               "somevalue2"
           };

            return Ok(values);
        }
    }
}