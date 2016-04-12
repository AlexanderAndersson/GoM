using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Account
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = Database.Accounts.Count() + 1; }
        }

        public Account()
        {
            ShoppingCart = new ShoppingCart();
            Payments = new List<Payment>();
        }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address { get; set; }

        public bool IsAdmin { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public List<Payment> Payments { get; set; }
    }
}