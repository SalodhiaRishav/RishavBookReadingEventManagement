using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RishavBookReadingEventManagement.ViewModels
{
    public class PostedCommentViewModel
    {
        public string EmailID { get; set; }
        public int BookReadingEventID { get; set; }

        [Required(ErrorMessage ="Empty Comments are not allowed")]
        public string Comments { get; set; }
        [Display(Name = "Commented On")]
        public DateTime CreatedOn { get; set; }
    }
}