using KelimeDefteriAPI.Context.EntityAbstracts;

namespace KelimeDefteriAPI.Context.EntityConcretes
{
    public class Word : IWord
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Definition> Definitions { get; set; } = new List<Definition>();
        public long RecordId { get; set; }
    }
}
