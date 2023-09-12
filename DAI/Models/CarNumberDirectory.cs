using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class CarNumberDirectory
    {
        public CarNumberDirectory()
        {
            CarOwnerships = new HashSet<CarOwnership>();
        }

        public int КодЗапису { get; set; }
        public int? НомерАвто { get; set; }
        public string? ФормаВластності { get; set; }
        public bool? НомерВільний { get; set; }

        public virtual Car? НомерАвтоNavigation { get; set; }
        public virtual ICollection<CarOwnership> CarOwnerships { get; set; }
    }
}
