using GoM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoM.Models
{
    public class Database
    {
        static public List<Account> Accounts { get; set; }

        static public Account Account { get; set; }

        static public string[] Tracks { get; set; }

        public Database()
        {
            Accounts = new List<Account>();

            Accounts.Add(new Account { Id = 1, Email = "teh.muzzi@gmail.com", Password = "1234", FirstName = "Mustafa", LastName = "Muhsin", Address = "Gangsta Street 69", IsAdmin = true });
            Accounts.Add(new Account { Id = 2, Email = "alexander.andersson.9347@gmail.com", Password = "1234", FirstName = "Alexander", LastName = "Andersson", Address = "Skånegatan 30", IsAdmin = false });
            Accounts.Add(new Account { Id = 3, Email = "callesandstrom@hotmail.com", Password = "1234", FirstName = "Calle", LastName = "Sandström", Address = "Mandolingatan 41", IsAdmin = true });

            Tracks = new string[] { "One Hell of a Song", "Song of Fire", "Gangsta Song", "Song Of Robert", "My Song to You", "The Love Song", "Cool Song from Hell", "Shit Song", "Song to Make You Cry", "The One Song And Only", "Song", "Super Song", "Whaddup Song", "This is a Song", "Hallelujah Song", "The Last Song Ever"  };
        }
    }
}