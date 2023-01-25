using AutoMapper;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KelimeDefteriAPI.MediatR.Handlers
{
    public class GetLastRecordHandler : IRequestHandler<GetLastRecordQuery, RecordViewModel>
    {
        private readonly KelifeDefteriAPIContext context;
        private readonly IMapper mapper;
        public GetLastRecordHandler(KelifeDefteriAPIContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<RecordViewModel> Handle(GetLastRecordQuery request, CancellationToken cancellationToken)
        {
            var records = context.Records.Include(vm => vm.Words).ThenInclude(word => word.Definitions);
            var lastRecord = await records.OrderBy(key => key.Id).LastOrDefaultAsync();
            var result = mapper.Map<RecordViewModel>(lastRecord);
            return result;

        }
    }
}
