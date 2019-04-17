using BucketList.Common.StaticConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BucketList.Common.CustomValidations
{
    public class DateGreaterThanNowAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTimeOffset)value >= DateTimeOffset.Now)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(BLMessages.DateGreaterThanNowError);
            }
        }
    }
}
