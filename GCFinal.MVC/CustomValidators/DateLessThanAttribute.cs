using System;
using System.ComponentModel.DataAnnotations;

namespace GCFinal.MVC.CustomValidators
{
    sealed public class DateLessThanAttribute : ValidationAttribute
    {
        public DateLessThanAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            var dt = (DateTime)value;
            if (dt < DateTime.Now.AddYears(1).AddDays(-2) && dt >= DateTime.Now.AddDays(-1))
            {
                return true;
            }

            return false;
        }
    }
}