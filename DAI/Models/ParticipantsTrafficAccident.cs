using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class ParticipantsTrafficAccident
    {
        public int НомерЗапису { get; set; }
        public int? НомерTrafficAccident { get; set; }
        public int? НомерАвто { get; set; }
        public string? Серія { get; set; }
        public string? МаркаАвто { get; set; }
        public int? ТипМашини { get; set; }

        public virtual TrafficAccident? НомерTrafficAccidentNavigation { get; set; }
        public virtual Car? НомерАвтоNavigation { get; set; }
        public virtual CarCategory? ТипМашиниNavigation { get; set; }
    }
}
