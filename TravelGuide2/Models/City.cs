using System.ComponentModel.DataAnnotations;

namespace TravelGuide.Models;

public class City
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    [Display(Name = "Название")]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    [Display(Name = "Регион")]
    public string Region { get; set; } = string.Empty;

    [Display(Name = "Население")]
    public int Population { get; set; }

    [Display(Name = "История")]
    public string History { get; set; } = string.Empty;

    [MaxLength(500)]
    [Display(Name = "Краткое описание")]
    public string ShortDescription { get; set; } = string.Empty;

    [MaxLength(500)]
    [Display(Name = "Фотография (URL или путь)")]
    public string PhotoUrl { get; set; } = string.Empty;

    [MaxLength(500)]
    [Display(Name = "Герб (URL или путь)")]
    public string CoatOfArmsUrl { get; set; } = string.Empty;

    public ICollection<Attraction> Attractions { get; set; } = new List<Attraction>();
}
