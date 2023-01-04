namespace KelimeDefteriAPI.Context.ViewModels
{
    public class DefinitionViewModel
    {
        public DefinitionViewModel()
        {

        }
        public DefinitionViewModel(string definition, string definitionType)
        {
            this.definition = definition;
            this.definitionType = definitionType;
        }
        public string definition { get; set; }
        public string definitionType { get; set; }
    }
}