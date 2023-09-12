using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class OwnerOrganization
    {
        public OwnerOrganization()
        {
            CarOwnerships = new HashSet<CarOwnership>();
        }

        public int НомерЗапису { get; set; }
        public string? Імя { get; set; }
        public string? Прізвище { get; set; }
        public string? ПоБатькові { get; set; }
        public DateTime? ДатаНародження { get; set; }
        public string? АдресаПроживанняВласника { get; set; }
        public string? СеріяПаспорта { get; set; }
        public string? НомерПаспорта { get; set; }
        public string? НазваОрганізації { get; set; }
        public string? Район { get; set; }
        public string? Адреса { get; set; }
        public string? Керівник { get; set; }

        public virtual ICollection<CarOwnership> CarOwnerships { get; set; }
    }
}
