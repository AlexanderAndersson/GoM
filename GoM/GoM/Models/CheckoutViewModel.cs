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
        [RegularExpression(@"\d{16}", ErrorMessage = "Must be 16 digits")]
        public int CardNumber { get; set; }

        [Required]
        [Display(Name = "Expiration Month")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Must be 2 digits")]
        public int ExpirationMonth { get; set; }

        [Required]
        [Display(Name = "Expiration Day")]
        [RegularExpression(@"\d{2}", ErrorMessage = "Must be 2 digits")]
        public int ExpirationDay { get; set; }

        [Required]
        [Display(Name = "CVC")]
        [RegularExpression(@"\d{3}", ErrorMessage = "Must be 3 digits")]
        public int CvcNumber { get; set; }
    }
}