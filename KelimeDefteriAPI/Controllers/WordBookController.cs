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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecordById(long id)
        {
            var record = await context.Records.Include(rec => rec.Words).ThenInclude(word => word.Definitions).FirstOrDefaultAsync(rec => rec.Id == id);
            RecordViewModel result = mapper.Map<RecordViewModel>(record);
            // Record will be retrieved by database and send to the client as RecordViewModel converting by Mapper.
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] RecordViewModel RecordVM)
        {
            var record = mapper.Map<Record>(RecordVM);
            context.Records.Add(record);
            await context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetRecordById),
                routeValues: new {id = record.Id},
                RecordVM
                ); // It returns the Location to retrieve created data and created record view model
        }
    }
}
