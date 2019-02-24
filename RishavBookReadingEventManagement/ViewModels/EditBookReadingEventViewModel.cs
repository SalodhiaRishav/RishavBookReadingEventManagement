using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Shared.CustomDataTypes;

namespace RishavBookReadingEventManagement.ViewModels
{
    public class EditBookReadingEventViewModel
    {
        public int ID { get; set; }
        [Required]
        public string BookTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }


        [Required]
        public string StartTime { get; set; }

        [Display(Name = "Event Type")]
        [Required]
        public EventType Type { get; set; }

        [Range(1, 4, ErrorMessage = "Duration must be in 1 to 4 hours")]
        public int? Duration { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(500)]
        public string OtherDetails { get; set; }

        public string InvitedEmails { get; set; }

        public DateTime CreatedOn { get; set; }
        public int UserID { get; set; }
    }
}