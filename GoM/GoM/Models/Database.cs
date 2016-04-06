using GoM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Database
    {
        static public List<Album> Albums { get; set; }

        static public List<Account> Accounts { get; set; }

        static public Account Account { get; set; }

        public Database()
        {
            Albums = new List<Album>();
            Accounts = new List<Account>();

            Albums.Add(new Album { Id = 1, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 2, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 3, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 4, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 5, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 6, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 7, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 8, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 9, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 89.90m, ImageSource = "/Images/mj-kingofpop.jpg" });

            Accounts.Add(new Account { Id = 1, Email = "callesandstrom@hotmail.com", Password = "1234", FirstName = "Calle", LastName = "Sandström", Address = "Mandolingatan 41", IsAdmin = true });
        }
    }
}