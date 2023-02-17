using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
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
