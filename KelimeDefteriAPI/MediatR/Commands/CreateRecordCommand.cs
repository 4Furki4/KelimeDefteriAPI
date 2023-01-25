using KelimeDefteriAPI.Context.ViewModels;
using MediatR;

namespace KelimeDefteriAPI.MediatR.Commands
{
    public class CreateRecordCommand : IRequest<long>
    {
        public RecordViewModel RecordVM { get; }

        public CreateRecordCommand(RecordViewModel recordVM)
        {
            RecordVM = recordVM;
        }
    }
}
