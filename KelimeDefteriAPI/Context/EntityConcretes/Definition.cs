using KelimeDefteriAPI.Context.EntityAbstracts;

namespace KelimeDefteriAPI.Context.EntityConcretes
{
    public class Definition : IDefinition
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string DescriptionType { get; set; } = string.Empty;
    }
}
