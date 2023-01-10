using AutoMapper;
using FluentValidation;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.Services.Validations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecordById(long id)
        {
            var record = await context.Records.Include(rec => rec.Words).ThenInclude(word => word.Definitions).FirstOrDefaultAsync(rec => rec.Id == id);
            if (record == null)
            {
                return NotFound("Record with provided id is not found");
            }
            RecordViewModel result = mapper.Map<RecordViewModel>(record);
            return Ok(result);
        }
        /**
         * It takes seach parameter to query date or word name to get the record with desired date or word
         * @param seach string value which can be date or word name
         */
        [HttpGet("{search}")]
        public async Task<IActionResult> RecordSearchByWordOrDate(string search)
        {
            Record? record = null;
            if (DateTime.TryParse(search, out DateTime parsedDate))
                record = await context.Records
                    .Include(rec => rec.Words)
                    .ThenInclude(word => word.Definitions)
                    .FirstOrDefaultAsync(rec => rec.Created.Date == parsedDate);
            else
            {
                var word = await context.Words.FirstOrDefaultAsync(word => word.Name == search);
                try
                {
                    record = word is not null ? await context.Records.Include(rec => rec.Words).ThenInclude(word => word.Definitions).SingleAsync(rec => rec.Id == word.RecordId) : null;
                }
                catch (Exception)
                {
                    return BadRequest("Given word has multiple records, please provide date instead."); // This error might be removed in the future.
                }
            }

            if (record is null)
            {
                return NotFound("Record with provided date or word is not found!");
            }
            var result = mapper.Map<RecordViewModel>(record);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddRecord([FromBody] RecordViewModel RecordVM)
        {
            using (var recordValidation = new RecordValidator())
            {
                try
                {
                    await recordValidation.ValidateAndThrowAsync(RecordVM);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            var record = mapper.Map<Record>(RecordVM);
            
            await context.Records.AddAsync(record);
            await context.SaveChangesAsync();
            
            return CreatedAtAction(
                nameof(GetRecordById),
                routeValues: new { id = record.Id },
                RecordVM
                ); // It returns the Location to retrieve created data and created record view model
        }
    }
}
