using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCFinal.MVC.Models
{
    public class BackDateAttribute : ValidationAttribute, IClientValidatable
    {
        private DateTime _MinDate;

        public BackDateAttribute()
        {
            _MinDate = DateTime.Today;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _StartDate = DateTime.Parse(value.ToString(), CultureInfo.InvariantCulture);
            DateTime _CurDate = DateTime.Today;

            int cmp = _StartDate.CompareTo(_CurDate);
            if (cmp > 0)
            {
                // date1 is greater means date1 is comes after date2
                return ValidationResult.Success;
            }
            else if (cmp < 0)
            {
                // date2 is greater means date1 is comes after date1
                return new ValidationResult(ErrorMessage);
            }
            else
            {
                // date1 is same as date2
                return ValidationResult.Success;
            }
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "restrictbackdates",
            };
            rule.ValidationParameters.Add("mindate", _MinDate);
            yield return rule;
        }
    }
}