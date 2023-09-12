using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class CarOwnership
    {
        public int КодЗапису { get; set; }
        public int? КодВласника { get; set; }
        public int? КодАвто { get; set; }

        public virtual CarNumberDirectory? КодАвтоNavigation { get; set; }
        public virtual OwnerOrganization? КодВласникаNavigation { get; set; }
    }
}
