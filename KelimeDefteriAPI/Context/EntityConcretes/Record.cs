using KelimeDefteriAPI.Context.EntityAbstracts;

namespace KelimeDefteriAPI.Context.EntityConcretes
{
    public class Record : IRecord
    {
        public long Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public ICollection<Word> Words { get; set; } = new List<Word>();
    }
}
