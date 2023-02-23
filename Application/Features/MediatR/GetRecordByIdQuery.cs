using Application.Repositories.RecordRepository;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR
{
    public class GetRecordByIdQueryRequest : IRequest<GetRecordByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetRecordByIdQueryRequest(int id)
        {
            Id = id;
        }
    }

    public class GetRecordByIdQueryRequestHandler : IRequestHandler<GetRecordByIdQueryRequest, GetRecordByIdQueryResponse>
    {
        readonly IRecordQueryRepository queryRepository;
        readonly IMapper mapper;

        public GetRecordByIdQueryRequestHandler(IMapper mapper, IRecordQueryRepository queryRepository)
        {
            this.mapper = mapper;
            this.queryRepository = queryRepository;
        }

        public async Task<GetRecordByIdQueryResponse> Handle(GetRecordByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Record record = await queryRepository.GetByIdAsync(request.Id);
            return new()
            {
                Record = record,
            };
        }
    }






    public class GetRecordByIdQueryResponse
    {
        public Record? Record { get; set; }
    }

}
