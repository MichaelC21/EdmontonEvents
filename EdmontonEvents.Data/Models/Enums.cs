using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EdmontonEvents.Data.Models
{
    public enum EventStatus
    {
        [Display(Name = "Draft")]
        Draft = 0,

        [Display(Name = "Published")]
        Published = 1,

        [Display(Name = "Cancelled")]
        Cancelled = 2
    }

    public enum EventCategory
    {
        [Display(Name = "Other")]
        Other = 0,

        [Display(Name = "Workshop")]
        Workshop = 1,

        [Display(Name = "Conference")]
        Conference = 2,

        [Display(Name = "Social")]
        Social = 3,

        [Display(Name = "Sports/Recreation")]
        SportsRecreation = 4,

        [Display(Name = "Concert")]
        Concert = 5
    }

}
