using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EdmontonEvents.Data.Entities;

public class Event
{
    [Key]
    public int EventID { get; set; }

    [Required]
    [StringLength(450)]
    [Display(Name = "Organizer")]
    public required string UserID { get; set; }

    [Required]
    [StringLength(200)]
    public required string Title { get; set; }

    [StringLength(500)]
    [DataType(DataType.MultilineText)]
    public string? Summary { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required]
    [Display(Name = "Start (UTC)")]
    [DataType(DataType.DateTime)]
    public DateTime StartUtc { get; set; }

    [Display(Name = "End (UTC)")]
    [DataType(DataType.DateTime)]
    public DateTime? EndUtc { get; set; }

    [Required]
    [Display(Name = "Status")]
    public EventStatus Status { get; set; } = EventStatus.Draft;

    [StringLength(2048)]
    [Url]
    [Display(Name = "Image URL")]
    public string? ImageUrl { get; set; }

    [StringLength(2048)]
    [Url]
    [Display(Name = "External link")]
    public string? ExternalUrl { get; set; }

    [Display(Name = "Free event")]
    public bool IsFree { get; set; }

    [Precision(10, 2)]
    [Range(0, 99999999.99)]
    [DataType(DataType.Currency)]
    public decimal? Price { get; set; }

    [StringLength(500)]
    [Display(Name = "Location")]
    public string? Location { get; set; }

    [Display(Name = "LocationId")]
    public int? LocationID { get; set; }

    [ForeignKey(nameof(LocationID))]
    public Location? EventLocation { get; set; }

    [Display(Name = "Category")]
    public int? CategoryID { get; set; }

    [ForeignKey(nameof(CategoryID))]
    public Category? Category { get; set; }

    [Required]
    [Display(Name = "Created")]
    public DateTime CreatedAtUtc { get; set; }

    [Required]
    [Display(Name = "Last updated")]
    public DateTime UpdatedAtUtc { get; set; }
}
