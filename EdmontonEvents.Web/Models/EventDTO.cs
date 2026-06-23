using EdmontonEvents.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EdmontonEvents.Web.Models
{
    public class EventDTO
    {
        public EventDTO()
        {
            FormResult = new FormResult();
        }


        [Display(Name = "First Name")]
        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Event Title")]
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime EventStartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime? EventEndDate { get; set; }

        [Display(Name = "Time zone")]
        public string? TimeZone { get; set; }

        [Display(Name = "Event Type")]
        public bool isInPerson { get; set; }

        [StringLength(2048)]
        [Url]
        [Display(Name = "Image URL")]
        public string? ImageUrl { get; set; }

        [StringLength(2048)]
        [Url]
        [Display(Name = "External link")]
        public string? ExternalUrl { get; set; }

        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Event Category")]
        public EventCategory EventCategory { get; set; }

        [StringLength(500)]
        [Display(Name = "Location")]
        public string? Location { get; set; }

        [Precision(10, 2)]
        [Range(0, 99999999.99)]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }

        public FormResult FormResult { get; set; }

    }
}
