using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class DriverCategory
    {
        public DriverCategory()
        {
            CarCategories = new HashSet<CarCategory>();
        }

        public int КодЗапису { get; set; }
        public string? НазваКатегорії { get; set; }
        public string? Опис { get; set; }

        public virtual ICollection<CarCategory> CarCategories { get; set; }
    }
}
