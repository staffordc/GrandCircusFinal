using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;

namespace GCFinal.MVC.Models
{
    sealed public class DateLessThanAttribute : ValidationAttribute, IClientValidatable
    {
        private DateTime _MaxDate;

        public DateLessThanAttribute()
        {
            _MaxDate = DateTime.Now.AddYears(1).AddDays(-2);
        }

        public DateTime MaxDate { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _StartDate = DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
            DateTime _CmpDate = DateTime.Now.AddYears(1).AddDays(-32);
            int cmp = _StartDate.CompareTo(_CmpDate);
            if (cmp < 0)
            {
                // date1 is less than date2 means start date is before one year from now
                return ValidationResult.Success;
            }
            else if (cmp > 0)
            {
                // date2 is greater means date1 is comes after date2
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                // date1 is same as date2
                return ValidationResult.Success;
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata,
            ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "restrictmorethanoneyear",
            };
            rule.ValidationParameters.Add("maxdate", _MaxDate);
            yield return rule;
        }
    }
}