namespace KelimeDefteriAPI.Context.ViewModels
{
    public class WordViewModel
    {
        
        public string Name { get; set; }

        public WordViewModel(string name, List<DefinitionViewModel> definitions)
        {
            Name = name;
            Definitions = definitions;
        }

        public List<DefinitionViewModel> Definitions { get; set; }
    }
}
