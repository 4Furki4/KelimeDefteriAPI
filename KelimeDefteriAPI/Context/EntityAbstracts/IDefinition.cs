namespace KelimeDefteriAPI.Context.EntityAbstracts
{
    public interface IDefinition
    {
        public long Id { get; set; }
        public long WordId { get; set; }
        string Description { get; set; }
        string DescriptionType { get; set; }
    }
}
