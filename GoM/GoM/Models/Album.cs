using GoM.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public Genre Genre { get; set; }

        public decimal Price { get; set; }

        public int NumberOfSongs { get; set; }

        public string ImageSource { get; set; }

        public int InStock { get; set; }
    }
}