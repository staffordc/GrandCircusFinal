using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime StartDate { get; set; }
        [Required]
        [Range(1, 30, ErrorMessage = "Enter a trip length between 1 and 30 days")]
        [Display(Name = "Number of Days Vacationing")]
        public int Duration { get; set; }
        
    }
}