namespace KelimeDefteriAPI.Context.ViewModels
{
    public class WordViewModel
    {
        public string Name = string.Empty;
        public List<DefinitionViewModel> Definitions { get; set; } = new List<DefinitionViewModel>();
    }
}
