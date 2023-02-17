using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class RecordViewModel
    {
        public RecordViewModel()
        {

        }
        public RecordViewModel(List<WordViewModel> words)
        {
            Words = words;
        }
        public List<WordViewModel> Words { get; set; }
        public string Created { get; set; }
    }
}
