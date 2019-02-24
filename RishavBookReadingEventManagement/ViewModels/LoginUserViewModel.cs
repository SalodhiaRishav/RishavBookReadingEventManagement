using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RishavBookReadingEventManagement.ViewModels
{
    public class LoginUserViewModel
    {
        
        [Display(Name = "Enter Email")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

    }
}