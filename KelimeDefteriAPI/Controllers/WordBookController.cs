using AutoMapper;
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
        private readonly IMapper mapper;
        public WordBookController(KelifeDefteriAPIContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
        public async Task<IActionResult> AddRecord([FromBody] RecordViewModel RecordVM)
        {
            // AutoMapper will be used to convert received data from client-side app.

            var record = mapper.Map<Record>(RecordVM);
            //await context.Records.AddAsync(record);
            //await context.SaveChangesAsync();
            return Ok(RecordVM);
        }
    }
}
