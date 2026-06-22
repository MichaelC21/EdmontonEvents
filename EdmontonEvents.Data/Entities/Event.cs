using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EdmontonEvents.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EdmontonEvents.Data.Entities;

public class Event
{
    [Key]
    public int EventID { get; set; }

    [Required]
    [StringLength(450)]
    public required string UserID { get; set; }

    [Required]
    [StringLength(20)]
    public required string OrganizerFirstName { get; set; }

    [Required]
    [StringLength(20)]
    public required string OrganizerLastName { get; set; }

    [Required]
    [StringLength(200)]
    public required string Title { get; set; }

    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartUtc { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime? EndUtc { get; set; }

    [Required]
    public EventStatus Status { get; set; }

    [StringLength(2048)]
    [Url]
    public string? ImageUrl { get; set; }

    [StringLength(2048)]
    [Url]
    public string? ExternalUrl { get; set; }

    [Required]
    public EventCategory EventCategory { get; set; }

    [Precision(10, 2)]
    [Range(0, 99999999.99)]
    [DataType(DataType.Currency)]
    public decimal? Price { get; set; }

    [StringLength(500)]
    public string? Location { get; set; }

    public int? LocationID { get; set; }

    [Required]
    public DateTime CreatedAtUtc { get; set; }

    [Required]
    public DateTime UpdatedAtUtc { get; set; }


    [ForeignKey(nameof(LocationID))]
    public virtual Location? EventLocation { get; set; }

    [ForeignKey(nameof(UserID))]
    public virtual UserAccount User { get; set; }
}
