using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class CheckoutViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [RegularExpression(@"\d{16}", ErrorMessage = "Måste bestå av 16 siffror")]
        public long CardNumber { get; set; }

        [Required]
        [Display(Name = "Month")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Måste bestå av 2 siffror")]
        public int ExpirationMonth { get; set; }

        [Required]
        [Display(Name = "Year")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Måste bestå av 2 siffror")]
        public int ExpirationYear { get; set; }

        [Required]
        [Display(Name = "CVC")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Måste bestå av 3 siffror")]
        public int CvcNumber { get; set; }
    }
}