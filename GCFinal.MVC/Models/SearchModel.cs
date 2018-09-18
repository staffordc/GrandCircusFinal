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
        [Display(Name = "Start of Travel")]
        [BackDate(ErrorMessage = "Back date entry not allowed")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DateLessThan(ErrorMessage = "Start date must be less than 11 months from now")]
        public DateTime StartDate { get; set; }

        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "The number must be positive and cannot be a decimal")]
        [Range(1, 30, ErrorMessage = "Enter a trip length between 1 and 30 days")]
        [Display(Name = "Number of Days Traveling")]
        public int Duration { get; set; }

    }

}