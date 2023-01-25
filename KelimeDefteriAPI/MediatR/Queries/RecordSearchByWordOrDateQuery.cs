using KelimeDefteriAPI.Context.ViewModels;
using MediatR;

namespace KelimeDefteriAPI.MediatR.Queries
{
    public class RecordSearchByWordOrDateQuery : IRequest<RecordViewModel>
    {
        public string search { get;}

        public RecordSearchByWordOrDateQuery(string search)
        {
            this.search = search;
        }
    }
}
