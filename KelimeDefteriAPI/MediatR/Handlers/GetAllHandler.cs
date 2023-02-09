using AutoMapper;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KelimeDefteriAPI.MediatR.Handlers
{
    public class GetAllHandler : IRequestHandler<GetAllQuery, List<RecordViewModel>>
    {
        private readonly KelifeDefteriAPIContext context;
        private readonly IMapper mapper;

        public GetAllHandler(KelifeDefteriAPIContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<RecordViewModel>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var data = await context.Records.Include(rec => rec.Words).ThenInclude(words => words.Definitions).ToListAsync();
            var record = mapper.Map<List<RecordViewModel>>(data);
            return record;
        }
    }
}
