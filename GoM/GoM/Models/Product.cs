﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Product
    {
        public int Id { get; set; }

        public Album Album { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

    }
}