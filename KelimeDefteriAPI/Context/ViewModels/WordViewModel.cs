namespace KelimeDefteriAPI.Context.ViewModels
{
    public class WordViewModel
    {
        public WordViewModel()
        {

        }
        public string Name { get; set; }

        public List<DefinitionViewModel> Definitions { get; set; }
    }
}
