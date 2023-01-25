using AutoMapper;
using FluentValidation;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.MediatR.Commands;
using KelimeDefteriAPI.MediatR.Queries;
using KelimeDefteriAPI.Services.Validations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
namespace KelimeDefteriAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("Basic")]
    public class WordBookController : ControllerBase
    {
        private readonly KelifeDefteriAPIContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public WordBookController(KelifeDefteriAPIContext context, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRecordById(long id)
        {
            var query = new GetRecordByIdQuery(id);
            var result = await mediator.Send(query);
            if (result == null)
            {
                return NotFound("Record with provided id is not found");
            }
            return Ok(result);
        }
        /**
         * It takes seach parameter to query date or word name to get the record with desired date or word
         * @param seach string value which can be date or word name
         */
        [HttpGet("{search}")]
        public async Task<IActionResult> RecordSearchByWordOrDate(string search)
        {
            var query = new RecordSearchByWordOrDateQuery(search);
            var result = await mediator.Send(query);
            if (result is null)
                return NotFound("Record with provided date or word is not found!");
            
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRecord([FromBody] RecordViewModel RecordVM)
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
            var command = new CreateRecordCommand(RecordVM);
            var result = await mediator.Send(command);
            return CreatedAtAction(
                nameof(GetRecordById),
                new { Id = result},
                RecordVM
                ); // It returns the Location to retrieve created data and created record view model
        }

        [HttpGet("last")]
        public async Task<IActionResult> LastRecord()
        {
            var query = new GetLastRecordQuery();
            var result = await mediator.Send(query);
            return result != null ? Ok(result) : NotFound(new { message = "Last record doesn't exist yet." });
        }
    }
}
