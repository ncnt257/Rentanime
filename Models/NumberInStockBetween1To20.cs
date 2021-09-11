using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rentanime.Models
{
    public class NumberInStockBetween1To20:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var anime = (Anime) validationContext.ObjectInstance;
            if (anime.NumberInStock >= 1 && anime.NumberInStock <= 20)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Number is stock must be between 1 and 20");
        }
    }
}