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

        static public string[] Tracks { get; set; }

        public Database()
        {
            Albums = new List<Album>();
            Accounts = new List<Account>();

            Albums.Add(new Album { Id = 1, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 15.99m, ImageSource = "/Images/mj-kingofpop.jpg" });
            Albums.Add(new Album { Id = 2, Title = "Back In Black", Genre = Genre.Rock, Artist = "AC/DC", InStock = 15, NumberOfSongs = 10, Price = 20.99m, ImageSource = "/Images/BackInBlack.jpg" });
            Albums.Add(new Album { Id = 3, Title = "Dookie", Genre = Genre.Rock, Artist = "Green Day", InStock = 10, NumberOfSongs = 14, Price = 49.99m, ImageSource = "/Images/GreenDay.jpg" });
            Albums.Add(new Album { Id = 4, Title = "Millennium", Genre = Genre.Pop, Artist = "Backstreet Boys", InStock = 5, NumberOfSongs = 12, Price = 29.99m, ImageSource = "/Images/BackstreetBoys.jpg" });
            Albums.Add(new Album { Id = 5, Title = "Infinite", Genre = Genre.HipHop, Artist = "Eminem", InStock = 10, NumberOfSongs = 11, Price = 19.99m, ImageSource = "/Images/EminemInfinite.jpg" });
            Albums.Add(new Album { Id = 6, Title = "Elvis The King", Genre = Genre.Rock, Artist = "Elvis Presley", InStock = 3, NumberOfSongs = 16, Price = 39.99m, ImageSource = "/Images/ElvisTheKing.jpg" });
            Albums.Add(new Album { Id = 7, Title = "Legend", Genre = Genre.Reggae, Artist = "Bob Marley", InStock = 9, NumberOfSongs = 14, Price = 49.99m, ImageSource = "/Images/BobMarley.jpg" });
            Albums.Add(new Album { Id = 8, Title = "Sings America", Genre = Genre.Pop, Artist = "David Hasselhoff", InStock = 50, NumberOfSongs = 15, Price = 29.99m, ImageSource = "/Images/David.jpg" });
            Albums.Add(new Album { Id = 9, Title = "Imagine", Genre = Genre.Rock, Artist = "John Lennon", InStock = 10, NumberOfSongs = 10, Price = 29.99m, ImageSource = "/Images/JohnLennon.jpg" });
            Albums.Add(new Album { Id = 10, Title = "Aquarium", Genre = Genre.Pop, Artist = "Aqua", InStock = 13, NumberOfSongs = 12, Price = 19.99m, ImageSource = "/Images/Aqua.jpg" });
            Albums.Add(new Album { Id = 11, Title = "In Utero", Genre = Genre.Grunge, Artist = "Nirvana", InStock = 12, NumberOfSongs = 12, Price = 19.99m, ImageSource = "/Images/Nirvana.jpg" });
            Albums.Add(new Album { Id = 12, Title = "The Chronic", Genre = Genre.HipHop, Artist = "Dr.Dre", InStock = 9, NumberOfSongs = 16, Price = 25.99m, ImageSource = "/Images/DrDre.jpeg" });

            Accounts.Add(new Account { Id = 1, Email = "teh.muzzi@gmail.com", Password = "1234", FirstName = "Mustafa", LastName = "Muhsin", Address = "Gangsta Street 69", IsAdmin = true });
            Accounts.Add(new Account { Id = 2, Email = "alexander.andersson.9347@gmail.com", Password = "1234", FirstName = "Alexander", LastName = "Andersson", Address = "Skånegatan 30", IsAdmin = false });
            Accounts.Add(new Account { Id = 3, Email = "callesandstrom@hotmail.com", Password = "1234", FirstName = "Calle", LastName = "Sandström", Address = "Mandolingatan 41", IsAdmin = true });

            Tracks = new string[] { "One Hell of a Song", "Song of Fire", "Gangsta Song", "Song Of Robert", "My Song to You", "The Love Song", "Cool Song from Hell", "Shit Song", "Song to Make You Cry", "The One Song And Only", "Song", "Super Song", "Whaddup Song", "This is a Song", "Hallelujah Song", "The Last Song Ever"  };
        }
    }
}