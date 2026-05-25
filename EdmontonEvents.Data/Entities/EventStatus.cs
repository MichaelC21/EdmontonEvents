using System.ComponentModel.DataAnnotations;

namespace EdmontonEvents.Data.Entities;

public enum EventStatus
{
    [Display(Name = "Draft")]
    Draft = 0,

    [Display(Name = "Published")]
    Published = 1,

    [Display(Name = "Cancelled")]
    Cancelled = 2
}
