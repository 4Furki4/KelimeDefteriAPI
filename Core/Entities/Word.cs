using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Word
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Definition> Definitions { get; set; } = new List<Definition>();
        public long RecordId { get; set; }
    }
}
