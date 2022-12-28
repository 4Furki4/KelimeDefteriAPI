namespace KelimeDefteriAPI.Context.EntityAbstracts
{
    public interface IDefinition
    {
        public long Id { get; set; }
        string Description { get; set; }
        string DescriptionType { get; set; }
    }
}
