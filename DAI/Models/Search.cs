using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class Search
    {
        public int КодЗапису { get; set; }
        public int? КодАвто { get; set; }
        public int КодВласника { get; set; }
        public DateTime? ДатаПропажі { get; set; }
        public string? ВмістБагажуСалону { get; set; }
    }
}
