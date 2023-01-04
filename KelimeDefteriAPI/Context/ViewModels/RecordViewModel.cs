﻿namespace KelimeDefteriAPI.Context.ViewModels
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
        public DateTime Created { get; set; }
    }
}
