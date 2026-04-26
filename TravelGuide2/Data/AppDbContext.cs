using Microsoft.EntityFrameworkCore;
using TravelGuide.Models;

namespace TravelGuide.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<City> Cities { get; set; }
    public DbSet<Attraction> Attractions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(e =>
        {
            e.HasKey(c => c.Id);
            e.Property(c => c.Name).IsRequired().HasMaxLength(200);
            e.Property(c => c.Region).IsRequired().HasMaxLength(200);
            e.Property(c => c.ShortDescription).HasMaxLength(500);
            e.Property(c => c.PhotoUrl).HasMaxLength(500);
            e.Property(c => c.CoatOfArmsUrl).HasMaxLength(500);
        });

        modelBuilder.Entity<Attraction>(e =>
        {
            e.HasKey(a => a.Id);
            e.Property(a => a.Name).IsRequired().HasMaxLength(200);
            e.Property(a => a.ShortDescription).HasMaxLength(500);
            e.Property(a => a.PhotoUrl).HasMaxLength(500);
            e.Property(a => a.WorkingHours).HasMaxLength(100);

            e.HasOne(a => a.City)
             .WithMany(c => c.Attractions)
             .HasForeignKey(a => a.CityId)
             .OnDelete(DeleteBehavior.Cascade);
        });

        // Seed данные — фотографии лежат в wwwroot/photos/
        // Названия файлов должны совпадать с тем, что ты положишь в папку photos
        modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                Name = "Москва",
                Region = "Центральный федеральный округ",
                Population = 12_600_000,
                ShortDescription = "Столица и крупнейший город России.",
                History = "Москва была основана в 1147 году князем Юрием Долгоруким. За свою историю город пережил монгольское нашествие, польскую интервенцию и наполеоновское нашествие, каждый раз возрождаясь и становясь сильнее. Сегодня это крупнейший мегаполис Европы и политический, экономический и культурный центр России.",
                PhotoUrl = "/photos/moscow.jpg",
                CoatOfArmsUrl = "/photos/moscow-coat.png"
            },
            new City
            {
                Id = 2,
                Name = "Санкт-Петербург",
                Region = "Северо-Западный федеральный округ",
                Population = 5_600_000,
                ShortDescription = "Культурная столица России на берегах Невы.",
                History = "Санкт-Петербург основан Петром I в 1703 году и был столицей Российской империи более двухсот лет. Город строился по образцу европейских столиц и стал символом реформ и открытости России миру. Известен белыми ночами, разводными мостами и богатейшим художественным наследием.",
                PhotoUrl = "/photos/spb.jpg",
                CoatOfArmsUrl = "/photos/spb-coat.png"
            },
            new City
            {
                Id = 3,
                Name = "Казань",
                Region = "Приволжский федеральный округ",
                Population = 1_300_000,
                ShortDescription = "Столица Татарстана — место слияния двух культур.",
                History = "Казань — один из крупнейших городов России, основанный в XIII веке. Расположена на слиянии Волги и Казанки. Город прошёл через период Казанского ханства, завоевание Иваном Грозным в 1552 году и стал центром татарской культуры в составе России. Сегодня известен как «третья столица» страны.",
                PhotoUrl = "/photos/kazan.jpg",
                CoatOfArmsUrl = "/photos/kazan-coat.png"
            }
        );

        modelBuilder.Entity<Attraction>().HasData(
            // Москва
            new Attraction
            {
                Id = 1, CityId = 1,
                Name = "Красная площадь",
                ShortDescription = "Главная площадь страны, сердце Москвы.",
                History = "Красная площадь возникла в конце XV века. Здесь проходили торги, объявлялись царские указы и совершались казни. Сегодня площадь — главная туристическая достопримечательность России, объект Всемирного наследия ЮНЕСКО.",
                PhotoUrl = "/photos/red-square.jpg",
                WorkingHours = "Открыта круглосуточно",
                TicketPrice = null
            },
            new Attraction
            {
                Id = 2, CityId = 1,
                Name = "Третьяковская галерея",
                ShortDescription = "Крупнейшее собрание русского изобразительного искусства.",
                History = "Основана купцом Павлом Третьяковым в 1856 году. Сегодня хранит более 180 000 экспонатов, охватывающих тысячелетнюю историю русского искусства — от древних икон до авангарда XX века.",
                PhotoUrl = "/photos/tretyakov.jpg",
                WorkingHours = "Вт–Вс: 10:00–18:00 (Чт, Пт до 21:00)",
                TicketPrice = 600
            },
            new Attraction
            {
                Id = 3, CityId = 1,
                Name = "Московский Кремль",
                ShortDescription = "Древняя крепость — резиденция Президента России.",
                History = "Первые укрепления на месте Кремля появились в XII веке. Современные стены из красного кирпича возведены в конце XV века итальянскими архитекторами. На территории расположены соборы, дворцы, музеи и Оружейная палата.",
                PhotoUrl = "/photos/kremlin.jpg",
                WorkingHours = "Пт–Ср: 10:00–17:00",
                TicketPrice = 700
            },
            // Санкт-Петербург
            new Attraction
            {
                Id = 4, CityId = 2,
                Name = "Эрмитаж",
                ShortDescription = "Один из крупнейших художественных музеев мира.",
                History = "Основан Екатериной II в 1764 году. Коллекция насчитывает более 3 миллионов экспонатов — картины, скульптуры, археологические находки из разных эпох и стран. Главное здание — Зимний дворец.",
                PhotoUrl = "/photos/hermitage.jpg",
                WorkingHours = "Вт, Чт, Сб, Вс: 10:30–18:00; Ср, Пт: 10:30–21:00",
                TicketPrice = 500
            },
            new Attraction
            {
                Id = 5, CityId = 2,
                Name = "Петергоф",
                ShortDescription = "Дворцово-парковый ансамбль с каскадами фонтанов.",
                History = "Заложен Петром I в начале XVIII века как летняя резиденция. Грандиозный Большой каскад с 64 фонтанами и позолоченными статуями открылся в 1723 году. Петергоф называют «русским Версалем».",
                PhotoUrl = "/photos/peterhof.jpg",
                WorkingHours = "Парк: 09:00–20:00 (фонтаны: май–октябрь)",
                TicketPrice = 450
            },
            // Казань
            new Attraction
            {
                Id = 6, CityId = 3,
                Name = "Казанский Кремль",
                ShortDescription = "Средневековая крепость, объект ЮНЕСКО.",
                History = "Основан в X–XI веках. После взятия Казани Иваном Грозным в 1552 году был перестроен русскими зодчими. На территории — мечеть Кул-Шариф, Благовещенский собор, Башня Сююмбике и президентский дворец.",
                PhotoUrl = "/photos/kazan-kremlin.jpg",
                WorkingHours = "Территория: 08:00–20:00 ежедневно",
                TicketPrice = null
            },
            new Attraction
            {
                Id = 7, CityId = 3,
                Name = "Мечеть Кул-Шариф",
                ShortDescription = "Главная мечеть Татарстана, символ Казани.",
                History = "Построена в 2005 году в память о мечети XVI века, разрушенной при взятии Казани. Вмещает до 1500 молящихся, минареты достигают 57 метров. Расположена на территории Казанского Кремля.",
                PhotoUrl = "/photos/kul-sharif.jpg",
                WorkingHours = "Ежедневно: 09:00–19:00",
                TicketPrice = 200
            }
        );
    }
}
