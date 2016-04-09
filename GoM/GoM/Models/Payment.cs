using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Payment
    {
        public Account Account { get; set; }

        public long CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        public int CvcNumber { get; set; }
    }
}