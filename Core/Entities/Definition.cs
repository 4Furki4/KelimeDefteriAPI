using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Definition
    {
        public long Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string DescriptionType { get; set; } = string.Empty;
        public long WordId { get; set; }
    }
}
