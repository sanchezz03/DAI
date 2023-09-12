using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class ListOfEventsTrafficAccident
    {
        public int КодЗапису { get; set; }
        public int НомерTrafficAccident { get; set; }
        public int КодКатегоріїПодії { get; set; }

        public virtual КатегоріїПодій КодКатегоріїПодіїNavigation { get; set; } = null!;
        public virtual TrafficAccident НомерTrafficAccidentNavigation { get; set; } = null!;
    }
}
