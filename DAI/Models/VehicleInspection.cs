using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class VehicleInspection
    {
        public int НомерОгляду { get; set; }
        public int? АвтоНаОгляд { get; set; }
        public string? НомерКвитанціїСплатиПодатку { get; set; }
        public decimal? СумаПлатежуЗаОгляд { get; set; }
        public string? ПеревіреноТехнічніХарактеристики { get; set; }
        public DateTime? ДатаОгляду { get; set; }

        public virtual Car? АвтоНаОглядNavigation { get; set; }
    }
}
