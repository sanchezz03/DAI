using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class CarCategory
    {
        public CarCategory()
        {
            Cars = new HashSet<Car>();
            ParticipantsTrafficAccidents = new HashSet<ParticipantsTrafficAccident>();
        }

        public int КодЗапису { get; set; }
        public string? НазваКатегорії { get; set; }
        public int? КатегоріяВодія { get; set; }

        public virtual DriverCategory? КатегоріяВодіяNavigation { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<ParticipantsTrafficAccident> ParticipantsTrafficAccidents { get; set; }
    }
}
