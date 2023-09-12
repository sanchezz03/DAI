using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAI.Models
{
    public partial class DAIContext : DbContext
    {
        public DAIContext()
        {
        }

        public DAIContext(DbContextOptions<DAIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<CarCategory> CarCategories { get; set; } = null!;
        public virtual DbSet<CarNumberDirectory> CarNumberDirectories { get; set; } = null!;
        public virtual DbSet<CarOwnership> CarOwnerships { get; set; } = null!;
        public virtual DbSet<DriverCategory> DriverCategories { get; set; } = null!;
        public virtual DbSet<ListOfEventsTrafficAccident> ListOfEventsTrafficAccidents { get; set; } = null!;
        public virtual DbSet<OwnerOrganization> OwnerOrganizations { get; set; } = null!;
        public virtual DbSet<ParticipantsTrafficAccident> ParticipantsTrafficAccidents { get; set; } = null!;
        public virtual DbSet<Search> Searches { get; set; } = null!;
        public virtual DbSet<TrafficAccident> TrafficAccidents { get; set; } = null!;
        public virtual DbSet<VehicleInspection> VehicleInspections { get; set; } = null!;
        public virtual DbSet<КатегоріїПодій> КатегоріїПодійs { get; set; } = null!;
        public virtual DbSet<GetOrganizationsByCriteria> GetOrganizationsByCriterias { get; set; }
        public virtual DbSet<GetOwnerInfoByLicensePlate> GetOwnerInfoByLicensePlates { get; set; }
        public virtual DbSet<VehicleInfo> VehicleInfos { get; set; }
        public virtual DbSet<GetDTPIAnalysis> GetDTPIAnalysiss { get; set; }
        public virtual DbSet<WantedCar> WantedCars { get; set; }
        public virtual DbSet<CalculateSearchEfficiency> CalculateSearchEfficiencies { get; set; }
        public virtual DbSet<GetPopularTheftMethods> GetPopularTheftMethods { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-1ULUPV2;Database=DAI;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.КодАвто)
                    .HasName("PK__Car__6D0803563F4AF29C");

                entity.ToTable("Car");

                entity.Property(e => e.КодАвто).HasColumnName("Код_АВТО");

                entity.Property(e => e.ДатаВипуску)
                    .HasColumnType("date")
                    .HasColumnName("Дата_випуску")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ДатаОстанньогоТехогляду)
                    .HasColumnType("date")
                    .HasColumnName("Дата_останнього_техогляду")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Колір)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.МаркаАвтомобіля)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Марка_автомобіля");

                entity.Property(e => e.НомериДвигуна)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("Номери_двигуна");

                entity.Property(e => e.НомернийЗнак)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Номерний_знак");

                entity.Property(e => e.ОбємДвигуна).HasColumnName("Обєм_двигуна");

                entity.Property(e => e.Серія)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.КатегоріяNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Категорія)
                    .HasConstraintName("FK__Car__Категорія__46E78A0C");
            });

            modelBuilder.Entity<CarCategory>(entity =>
            {
                entity.HasKey(e => e.КодЗапису)
                    .HasName("PK__Car_cate__C0C4DC9B0B5E08B5");

                entity.ToTable("Car_category");

                entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");

                entity.Property(e => e.КатегоріяВодія).HasColumnName("Категорія_водія");

                entity.Property(e => e.НазваКатегорії)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Назва_категорії");

                entity.HasOne(d => d.КатегоріяВодіяNavigation)
                    .WithMany(p => p.CarCategories)
                    .HasForeignKey(d => d.КатегоріяВодія)
                    .HasConstraintName("FK__Car_categ__Катег__4222D4EF");
            });

            modelBuilder.Entity<CarNumberDirectory>(entity =>
            {
                entity.HasKey(e => e.КодЗапису)
                    .HasName("PK__Car_Numb__C0C4DC9BA6875EB8");

                entity.ToTable("Car_Number_Directory");

                entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");

                entity.Property(e => e.НомерАвто).HasColumnName("Номер_АВТО");

                entity.Property(e => e.НомерВільний).HasColumnName("Номер_вільний");

                entity.Property(e => e.ФормаВластності)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Форма_властності");

                entity.HasOne(d => d.НомерАвтоNavigation)
                    .WithMany(p => p.CarNumberDirectories)
                    .HasForeignKey(d => d.НомерАвто)
                    .HasConstraintName("FK__Car_Numbe__Номер__534D60F1");
            });

            modelBuilder.Entity<CarOwnership>(entity =>
            {
                entity.HasKey(e => e.КодЗапису)
                    .HasName("PK__Car_Owne__C0C4DC9BB04E5A54");

                entity.ToTable("Car_Ownership");

                entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");

                entity.Property(e => e.КодАвто).HasColumnName("Код_АВТО");

                entity.Property(e => e.КодВласника).HasColumnName("Код_власника");

                entity.HasOne(d => d.КодАвтоNavigation)
                    .WithMany(p => p.CarOwnerships)
                    .HasForeignKey(d => d.КодАвто)
                    .HasConstraintName("FK__Car_Owner__Код_А__5BE2A6F2");

                entity.HasOne(d => d.КодВласникаNavigation)
                    .WithMany(p => p.CarOwnerships)
                    .HasForeignKey(d => d.КодВласника)
                    .HasConstraintName("FK__Car_Owner__Код_в__5CD6CB2B");
            });

            modelBuilder.Entity<DriverCategory>(entity =>
            {
                entity.HasKey(e => e.КодЗапису)
                    .HasName("PK__Driver_C__C0C4DC9B51E0796F");

                entity.ToTable("Driver_Categories");

                entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");

                entity.Property(e => e.НазваКатегорії)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Назва_категорії");

                entity.Property(e => e.Опис).HasColumnType("text");
            });

            modelBuilder.Entity<ListOfEventsTrafficAccident>(entity =>
            {
                entity.HasKey(e => e.КодЗапису)
                    .HasName("PK__List_of___C0C4DC9B9E737B42");

                entity.ToTable("List_of_Events_Traffic_Accident");

                entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");

                entity.Property(e => e.КодКатегоріїПодії).HasColumnName("Код_категорії_події");

                entity.Property(e => e.НомерTrafficAccident).HasColumnName("Номер_Traffic_Accident");

                entity.HasOne(d => d.КодКатегоріїПодіїNavigation)
                    .WithMany(p => p.ListOfEventsTrafficAccidents)
                    .HasForeignKey(d => d.КодКатегоріїПодії)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__List_of_E__Код_к__3D5E1FD2");

                entity.HasOne(d => d.НомерTrafficAccidentNavigation)
                    .WithMany(p => p.ListOfEventsTrafficAccidents)
                    .HasForeignKey(d => d.НомерTrafficAccident)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__List_of_E__Номер__3C69FB99");
            });

            modelBuilder.Entity<OwnerOrganization>(entity =>
            {
                entity.HasKey(e => e.НомерЗапису)
                    .HasName("PK__Owner_Or__0FD0EBA29F662F30");

                entity.ToTable("Owner_Organization");

                entity.Property(e => e.НомерЗапису).HasColumnName("Номер_запису");

                entity.Property(e => e.Імя)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Адреса)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.АдресаПроживанняВласника)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Адреса_проживання_власника");

                entity.Property(e => e.ДатаНародження)
                    .HasColumnType("date")
                    .HasColumnName("Дата_народження")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Керівник)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.НазваОрганізації)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Назва_організації");

                entity.Property(e => e.НомерПаспорта)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("Номер_паспорта");

                entity.Property(e => e.ПоБатькові)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("По_батькові");

                entity.Property(e => e.Прізвище)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Район)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.СеріяПаспорта)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("Серія_паспорта");
            });

            modelBuilder.Entity<ParticipantsTrafficAccident>(entity =>
            {
                entity.HasKey(e => e.НомерЗапису)
                    .HasName("PK__Particip__0FD0EBA21AF202C2");

                entity.ToTable("Participants_Traffic_Accident");

                entity.Property(e => e.НомерЗапису).HasColumnName("Номер_запису");

                entity.Property(e => e.МаркаАвто)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Марка_АВТО");

                entity.Property(e => e.НомерTrafficAccident).HasColumnName("Номер_Traffic_Accident");

                entity.Property(e => e.НомерАвто).HasColumnName("Номер_АВТО");

                entity.Property(e => e.Серія)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ТипМашини).HasColumnName("Тип_машини");

                entity.HasOne(d => d.НомерTrafficAccidentNavigation)
                    .WithMany(p => p.ParticipantsTrafficAccidents)
                    .HasForeignKey(d => d.НомерTrafficAccident)
                    .HasConstraintName("FK__Participa__Номер__49C3F6B7");

                entity.HasOne(d => d.НомерАвтоNavigation)
                    .WithMany(p => p.ParticipantsTrafficAccidents)
                    .HasForeignKey(d => d.НомерАвто)
                    .HasConstraintName("FK__Participa__Номер__4AB81AF0");

                entity.HasOne(d => d.ТипМашиниNavigation)
                    .WithMany(p => p.ParticipantsTrafficAccidents)
                    .HasForeignKey(d => d.ТипМашини)
                    .HasConstraintName("FK__Participa__Тип_м__4BAC3F29");
            });

            modelBuilder.Entity<Search>(entity =>
            {
                entity.HasKey(e => e.КодЗапису)
                    .HasName("PK__Search__C0C4DC9B9E89B165");

                entity.ToTable("Search");

                entity.Property(e => e.КодЗапису).HasColumnName("Код_запису");

                entity.Property(e => e.ВмістБагажуСалону)
                    .HasColumnType("text")
                    .HasColumnName("Вміст_багажу_салону");

                entity.Property(e => e.ДатаПропажі)
                    .HasColumnType("date")
                    .HasColumnName("Дата_пропажі")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.КодАвто).HasColumnName("Код_АВТО");

                entity.Property(e => e.КодВласника).HasColumnName("Код_власника");
            });

            modelBuilder.Entity<TrafficAccident>(entity =>
            {
                entity.HasKey(e => e.НомерTrafficAccident)
                    .HasName("PK__Traffic___22C0B50B5DB45339");

                entity.ToTable("Traffic_Accident");

                entity.Property(e => e.НомерTrafficAccident).HasColumnName("Номер_Traffic_Accident");

                entity.Property(e => e.ДатаTrafficAccident)
                    .HasColumnType("date")
                    .HasColumnName("Дата_Traffic_Accident")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ДорожніУмови)
                    .HasColumnType("text")
                    .HasColumnName("Дорожні_умови");

                entity.Property(e => e.ЗникненняВинуватця).HasColumnName("Зникнення_винуватця");

                entity.Property(e => e.КороткийЗміст)
                    .HasColumnType("text")
                    .HasColumnName("Короткий_зміст");

                entity.Property(e => e.КількістьПостраждалих).HasColumnName("Кількість_постраждалих");

                entity.Property(e => e.МісцеПодії)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Місце_події");

                entity.Property(e => e.Причина).HasColumnType("text");

                entity.Property(e => e.СумаЗбитків)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Сума_збитків");
            });

            modelBuilder.Entity<VehicleInspection>(entity =>
            {
                entity.HasKey(e => e.НомерОгляду)
                    .HasName("PK__Vehicle___D896CC3BF64993E5");

                entity.ToTable("Vehicle_Inspection");

                entity.Property(e => e.НомерОгляду).HasColumnName("Номер_огляду");

                entity.Property(e => e.АвтоНаОгляд).HasColumnName("Авто_на_огляд");

                entity.Property(e => e.ДатаОгляду)
                    .HasColumnType("date")
                    .HasColumnName("Дата_огляду")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.НомерКвитанціїСплатиПодатку)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Номер_квитанції_сплати_податку");

                entity.Property(e => e.ПеревіреноТехнічніХарактеристики)
                    .HasColumnType("text")
                    .HasColumnName("Перевірено_технічні_характеристики");

                entity.Property(e => e.СумаПлатежуЗаОгляд)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Сума_платежу_за_огляд");

                entity.HasOne(d => d.АвтоНаОглядNavigation)
                    .WithMany(p => p.VehicleInspections)
                    .HasForeignKey(d => d.АвтоНаОгляд)
                    .HasConstraintName("FK__Vehicle_I__Авто___4F7CD00D");
            });

            modelBuilder.Entity<КатегоріїПодій>(entity =>
            {
                entity.HasKey(e => e.КодКатегорії)
                    .HasName("PK__Категорі__111B695BE968DD8D");

                entity.ToTable("Категорії_подій");

                entity.Property(e => e.КодКатегорії).HasColumnName("Код_Категорії");

                entity.Property(e => e.НазваКатегорії)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Назва_Категорії");

                entity.Property(e => e.Опис).HasColumnType("text");
            });

            modelBuilder.Entity<GetOrganizationsByCriteria>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<GetOwnerInfoByLicensePlate>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<VehicleInfo>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<GetDTPIAnalysis>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<WantedCar>(entity =>
            {
                entity.HasNoKey(); 
            });

            modelBuilder.Entity<CalculateSearchEfficiency>(entity =>
            {
                entity.HasNoKey(); 
            });

            modelBuilder.Entity<GetPopularTheftMethods>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
