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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(long id)
        {
            // Record will be retrieved by database and send to the client as RecordViewModel converting by Mapper.
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] RecordViewModel RecordVM)
        {
            var record = mapper.Map<Record>(RecordVM);
            context.Records.Add(record);
            await context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecordById), routeValues: new {id = record.Id}, RecordVM); // It returns the Location to retrieve created data and created record view model
        }
    }
}
