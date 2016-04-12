using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Product
    {
        public Album Album { get; set; }

        public int Quantity { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

    }
}