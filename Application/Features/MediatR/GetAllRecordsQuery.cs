using Application.Repositories.RecordRepository;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR
{
    public class GetAllRecordsQueryRequest : IRequest<GetAllRecordsQueryResponse> { }


    public class GetAllRecordsQueryRequestHandler : IRequestHandler<GetAllRecordsQueryRequest, GetAllRecordsQueryResponse>
    {
        private readonly IRecordQueryRepository queryRepository;
        private readonly IMapper mapper;

        public GetAllRecordsQueryRequestHandler(IRecordQueryRepository queryRepository, IMapper mapper)
        {
            this.queryRepository = queryRepository;
            this.mapper = mapper;
        }


        public async Task<GetAllRecordsQueryResponse> Handle(GetAllRecordsQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await queryRepository.Table.AsNoTracking().Include(rec => rec.Words).ThenInclude(w => w.Definitions).ToListAsync();
            var record = mapper.Map<List<RecordViewModel>>(data);
            return new()
            {
                Records = data
            };
        }
    }


    public class GetAllRecordsQueryResponse
    {
        public List<Record>? Records { get; set; }
    }
}
