using KelimeDefteriAPI.Context.ViewModels;
using MediatR;

namespace KelimeDefteriAPI.MediatR.Queries
{
    public class GetRecordByIdQuery : IRequest<RecordViewModel>
    {
        public long Id { get;}
        public GetRecordByIdQuery(long ıd)
        {
            Id = ıd;
        }
    }
}
