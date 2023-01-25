using KelimeDefteriAPI.Context.ViewModels;
using MediatR;

namespace KelimeDefteriAPI.MediatR.Queries
{
    public class GetLastRecordQuery  : IRequest<RecordViewModel>
    {

    }
}
