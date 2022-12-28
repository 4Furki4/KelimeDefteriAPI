using KelimeDefteriAPI.Context.EntityConcretes;

namespace KelimeDefteriAPI.Context.EntityAbstracts
{
    public interface IRecord
    {
        public long Id { get; set; }
        DateTime Created { get; set; }
        DateTime? Modified { get; set; }
        ICollection<Word> Words { get; set; }

    }
}
