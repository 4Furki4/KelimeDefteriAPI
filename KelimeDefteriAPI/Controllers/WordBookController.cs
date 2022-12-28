using Microsoft.AspNetCore.Mvc;

namespace KelimeDefteriAPI.Controllers
{
    public class WordBookController : ControllerBase
    {
        [HttpPost]
        public IActionResult AddRecord()
        {
            return Ok();
        }
    }
}
