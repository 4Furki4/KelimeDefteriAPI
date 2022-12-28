using KelimeDefteriAPI.Context.EntityConcretes;

namespace KelimeDefteriAPI.Context.EntityAbstracts
{
    public interface IWord
    {
        public long Id { get; set; }
        string Name { get; set; }
        ICollection<Definition> Definitions { get; set; }
    }
}
