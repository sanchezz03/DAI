using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class КатегоріїПодій
    {
        public КатегоріїПодій()
        {
            ListOfEventsTrafficAccidents = new HashSet<ListOfEventsTrafficAccident>();
        }

        public int КодКатегорії { get; set; }
        public string НазваКатегорії { get; set; } = null!;
        public string? Опис { get; set; }

        public virtual ICollection<ListOfEventsTrafficAccident> ListOfEventsTrafficAccidents { get; set; }
    }
}
