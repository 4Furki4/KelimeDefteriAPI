using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MediatR
{
    public class GetLastRecordQueryRequest : IRequest<GetLastRecordQueryResponse>
    {

    }


    public class GetLastRecordQueryRequestHandler : IRequestHandler<GetLastRecordQueryRequest, GetLastRecordQueryResponse>
    {
        public Task<GetLastRecordQueryResponse> Handle(GetLastRecordQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


    public class GetLastRecordQueryResponse
    {
        public Record? Record { get; set; }
    }
}
