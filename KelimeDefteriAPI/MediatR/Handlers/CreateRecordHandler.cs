using AutoMapper;
using KelimeDefteriAPI.Context;
using KelimeDefteriAPI.Context.EntityConcretes;
using KelimeDefteriAPI.Context.ViewModels;
using KelimeDefteriAPI.MediatR.Commands;
using MediatR;

namespace KelimeDefteriAPI.MediatR.Handlers
{
    public class CreateRecordHandler : IRequestHandler<CreateRecordCommand, long>
    {
        private readonly KelifeDefteriAPIContext context;
        private readonly IMapper mapper;
        public CreateRecordHandler(KelifeDefteriAPIContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<long> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            var record = mapper.Map<Record>(request.RecordVM);

            await context.Records.AddAsync(record);
            await context.SaveChangesAsync();
            return record.Id;
        }
    }
}
