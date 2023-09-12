using System;
using System.Collections.Generic;

namespace DAI.Models
{
    public partial class Car
    {
        public Car()
        {
            CarNumberDirectories = new HashSet<CarNumberDirectory>();
            ParticipantsTrafficAccidents = new HashSet<ParticipantsTrafficAccident>();
            VehicleInspections = new HashSet<VehicleInspection>();
        }

        public int КодАвто { get; set; }
        public int? Категорія { get; set; }
        public string? НомернийЗнак { get; set; }
        public string? Серія { get; set; }
        public string? МаркаАвтомобіля { get; set; }
        public DateTime? ДатаВипуску { get; set; }
        public double? ОбємДвигуна { get; set; }
        public string? НомериДвигуна { get; set; }
        public bool? Шасі { get; set; }
        public bool? Кузов { get; set; }
        public string? Колір { get; set; }
        public DateTime? ДатаОстанньогоТехогляду { get; set; }

        public virtual CarCategory? КатегоріяNavigation { get; set; }
        public virtual ICollection<CarNumberDirectory> CarNumberDirectories { get; set; }
        public virtual ICollection<ParticipantsTrafficAccident> ParticipantsTrafficAccidents { get; set; }
        public virtual ICollection<VehicleInspection> VehicleInspections { get; set; }
    }
}
