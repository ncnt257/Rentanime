﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentanime.Models
{
    public class Min18IfAMember:ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == Customer.Unknown || customer.MembershipTypeId == Customer.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
            {
                return new ValidationResult("Birthday is required");
            }

            var age = DateTime.Now.Year - customer.Birthdate.Value.Year;
            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18 years old");
        }
    }
}