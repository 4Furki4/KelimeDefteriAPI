using AutoMapper;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.MediatR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KelimeDefteriAPI.MediatR.Handlers
{
    public class GetRecordByIdHandler : IRequestHandler<GetRecordByIdQuery, RecordViewModel>
    {
        private readonly KelifeDefteriAPIContext context;
        private readonly IMapper mapper;
        public GetRecordByIdHandler(KelifeDefteriAPIContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<RecordViewModel> Handle(GetRecordByIdQuery request, CancellationToken cancellationToken)
        {
            var record = await context.Records.Include(rec => rec.Words).ThenInclude(word => word.Definitions).FirstOrDefaultAsync(rec => rec.Id == request.Id);
            if (record == null)
            {
                return null;
            }
            RecordViewModel result = mapper.Map<RecordViewModel>(record);
            return result;
        }
    }
}
