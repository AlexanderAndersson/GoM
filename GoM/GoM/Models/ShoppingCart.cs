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

        public decimal Amount { get { return Products.Sum(p => p.Album.Price * p.Quantity); } }

        public int NumberOfProducts { get { return Products.Count(); } }
    }
}