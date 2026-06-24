using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EdmontonEvents.Data.Entities;

public class Location
{
    [Key]
    public int LocationID { get; set; }

    [StringLength(200)]
    public required string Name { get; set; }

    [StringLength(200)]
    public string? AddressLine1 { get; set; }

    [StringLength(200)]
    public string? AddressLine2 { get; set; }

    [Required]
    [StringLength(200)]
    public string City { get; set; } = "Edmonton";

    [Required]
    [StringLength(200)]
    public string Province { get; set; } = "AB";

    [StringLength(10)]
    public string? PostalCode { get; set; }


    [Precision(9, 6)]
    [Range(-90, 90)]
    public decimal? Latitude { get; set; }

    [Precision(9, 6)]
    [Range(-180, 180)]
    public decimal? Longitude { get; set; }

    public ICollection<Event> Events { get; set; } = new List<Event>();
}
