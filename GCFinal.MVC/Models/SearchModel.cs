using GCFinal.MVC.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace GCFinal.MVC.Models
{
    public class SearchModel
    {
        [Required]
        [Display(Name = "City, State Abbv. OR Zip Code")]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Please enter a date")]
        [Display(Name = "Start of Vacation")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DateLessThan(ErrorMessage = "The date cannot be more than one year from yesterday in the future")]
        public DateTime StartDate { get; set; }

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "The number must be positive and cannot be a decimal")]
        [Range(1, 30, ErrorMessage = "Enter a trip length between 1 and 30 days")]
        [Display(Name = "Number of Days Vacationing")]
        public int Duration { get; set; }

    }

}