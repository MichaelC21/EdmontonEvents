using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EdmontonEvents.Data.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Category
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Category name")]
    public required string Name { get; set; }

    [StringLength(500)]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

    [InverseProperty(nameof(Event.Category))]
    public ICollection<Event> Events { get; set; } = new List<Event>();
}
