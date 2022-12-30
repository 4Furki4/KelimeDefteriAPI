using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace KelimeDefteriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordBookController : ControllerBase
    {
        private readonly KelifeDefteriAPIContext context;

        public WordBookController(KelifeDefteriAPIContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> LastRecord()
        {
            var hasRecord = context.Records.Any();
            if (!hasRecord)
            {
                var rec = new Record();
                rec.Words = new List<Word>()
                {
                    new Word()
                    {
                        Name = "TEST1",
                        Definitions = new List<Definition>()
                        {
                            new Definition() {Description = "test1description", DescriptionType = "test1descriptionType"},
                            new Definition() {Description = "test2description", DescriptionType = "test2descriptionType"}
                        }
                    }
                };
                rec.Created = DateTime.Now;
                await context.Records.AddAsync(rec);
                await context.SaveChangesAsync();
            }

            return Ok(context.Records.Where(rec => rec.Id == 1 ));

        }


        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] RecordViewModel Record)
        {
            // AutoMapper will be used to convert received data from client-side app.
            return Ok();
        }
    }
}
