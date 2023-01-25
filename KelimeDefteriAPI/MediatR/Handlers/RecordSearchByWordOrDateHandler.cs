using AutoMapper;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KelimeDefteriAPI.MediatR.Handlers
{
    public class RecordSearchByWordOrDateHandler : IRequestHandler<RecordSearchByWordOrDateQuery, RecordViewModel>
    {
        private readonly KelifeDefteriAPIContext context;
        private readonly IMapper mapper;
        public RecordSearchByWordOrDateHandler(KelifeDefteriAPIContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        async Task<RecordViewModel> IRequestHandler<RecordSearchByWordOrDateQuery, RecordViewModel>.Handle(RecordSearchByWordOrDateQuery request, CancellationToken cancellationToken)
        {
            Record? record = null;
            if (DateTime.TryParse(request.search, out DateTime parsedDate))
                record = await context.Records
                    .Include(rec => rec.Words)
                    .ThenInclude(word => word.Definitions)
                    .FirstOrDefaultAsync(rec => rec.Created.Date == parsedDate);
            else
            {
                var word = await context.Words.FirstOrDefaultAsync(word => word.Name == request.search);
                try
                {
                    record = word is not null ? await context.Records.Include(rec => rec.Words).ThenInclude(word => word.Definitions).SingleAsync(rec => rec.Id == word.RecordId) : null;
                }
                catch (Exception)
                {
                    throw new BadHttpRequestException("Given word has multiple records, please provide date instead.");
                }
            }
            var result = mapper.Map<RecordViewModel>(record);
            return result;
        }
    }
}
