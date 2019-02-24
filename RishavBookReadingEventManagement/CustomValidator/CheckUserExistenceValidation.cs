using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RishavBookReadingEventManagement.CustomValidator
{
    public class CheckUserExistenceValidation : ValidationAttribute
    {
        BusinessLogics businessLogics = new BusinessLogics();        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                if(businessLogics.CheckEmailExistence(email))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Email Already Exists");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}