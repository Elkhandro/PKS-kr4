using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Models;

public class Attraction
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    [Display(Name = "Название")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "История / описание")]
    public string History { get; set; } = string.Empty;

    [MaxLength(500)]
    [Display(Name = "Краткое описание")]
    public string ShortDescription { get; set; } = string.Empty;

    [MaxLength(500)]
    [Display(Name = "Фотография (URL или путь)")]
    public string PhotoUrl { get; set; } = string.Empty;

    [MaxLength(100)]
    [Display(Name = "Часы работы")]
    public string WorkingHours { get; set; } = string.Empty;

    [Display(Name = "Стоимость посещения (руб.)")]
    public decimal? TicketPrice { get; set; }

    public int CityId { get; set; }
    public City? City { get; set; }
}
