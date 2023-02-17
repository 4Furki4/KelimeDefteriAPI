using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
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
