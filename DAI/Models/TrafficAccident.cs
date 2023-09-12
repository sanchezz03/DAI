using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class TrafficAccident
    {
        public TrafficAccident()
        {
            ListOfEventsTrafficAccidents = new HashSet<ListOfEventsTrafficAccident>();
            ParticipantsTrafficAccidents = new HashSet<ParticipantsTrafficAccident>();
        }

        public int НомерTrafficAccident { get; set; }
        public DateTime? ДатаTrafficAccident { get; set; }
        public string? МісцеПодії { get; set; }
        public string? КороткийЗміст { get; set; }
        public int? КількістьПостраждалих { get; set; }
        public decimal? СумаЗбитків { get; set; }
        public string? Причина { get; set; }
        public string? ДорожніУмови { get; set; }
        public bool? ЗникненняВинуватця { get; set; }

        public virtual ICollection<ListOfEventsTrafficAccident> ListOfEventsTrafficAccidents { get; set; }
        public virtual ICollection<ParticipantsTrafficAccident> ParticipantsTrafficAccidents { get; set; }
    }
}
