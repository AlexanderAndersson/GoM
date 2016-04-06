using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public Account Account { get; set; }

        public decimal Amount
        {
            get
            {
                decimal amount = 0;

                foreach (var item in Products)
                {
                    amount += item.Album.Price;
                }

                return amount;
            }
        }

        public int NumberOfProducts { get { return Products.Count(); } }
    }
}