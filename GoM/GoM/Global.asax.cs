using GoM.Helpers;
using GoM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GoM
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            Database db = new Database();
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["Albums"] = new List<Album>
            {
                new Album { Id = 1, Title = "King Of Pop", Genre = Genre.Pop, Artist = "Michael Jackson", InStock = 7, NumberOfSongs = 12, Price = 15.99m, ImageSource = "/Images/mj-kingofpop.jpg" },
                new Album { Id = 2, Title = "Back In Black", Genre = Genre.Rock, Artist = "AC/DC", InStock = 15, NumberOfSongs = 10, Price = 20.99m, ImageSource = "/Images/BackInBlack.jpg" },
                new Album { Id = 3, Title = "Dookie", Genre = Genre.Rock, Artist = "Green Day", InStock = 10, NumberOfSongs = 14, Price = 49.99m, ImageSource = "/Images/GreenDay.jpg" },
                new Album { Id = 4, Title = "Millennium", Genre = Genre.Pop, Artist = "Backstreet Boys", InStock = 5, NumberOfSongs = 12, Price = 29.99m, ImageSource = "/Images/BackstreetBoys.jpg" },
                new Album { Id = 5, Title = "Infinite", Genre = Genre.HipHop, Artist = "Eminem", InStock = 10, NumberOfSongs = 11, Price = 19.99m, ImageSource = "/Images/EminemInfinite.jpg" },
                new Album { Id = 6, Title = "Elvis The King", Genre = Genre.Rock, Artist = "Elvis Presley", InStock = 3, NumberOfSongs = 16, Price = 39.99m, ImageSource = "/Images/ElvisTheKing.jpg" },
                new Album { Id = 7, Title = "Legend", Genre = Genre.Reggae, Artist = "Bob Marley", InStock = 9, NumberOfSongs = 14, Price = 49.99m, ImageSource = "/Images/BobMarley.jpg" },
                new Album { Id = 8, Title = "Sings America", Genre = Genre.Pop, Artist = "David Hasselhoff", InStock = 50, NumberOfSongs = 15, Price = 29.99m, ImageSource = "/Images/David.jpg" },
                new Album { Id = 9, Title = "Imagine", Genre = Genre.Rock, Artist = "John Lennon", InStock = 10, NumberOfSongs = 10, Price = 29.99m, ImageSource = "/Images/JohnLennon.jpg" },
                new Album { Id = 10, Title = "Aquarium", Genre = Genre.Pop, Artist = "Aqua", InStock = 13, NumberOfSongs = 12, Price = 19.99m, ImageSource = "/Images/Aqua.jpg" },
                new Album { Id = 11, Title = "In Utero", Genre = Genre.Grunge, Artist = "Nirvana", InStock = 12, NumberOfSongs = 12, Price = 19.99m, ImageSource = "/Images/Nirvana.jpg" },
                new Album { Id = 12, Title = "The Chronic", Genre = Genre.HipHop, Artist = "Dr.Dre", InStock = 9, NumberOfSongs = 16, Price = 25.99m, ImageSource = "/Images/DrDre.jpeg" },
                new Album { Id = 13, Title = "Rebel Music", Genre = Genre.Reggae, Artist = "Bob Marley", InStock = 10, NumberOfSongs = 12, Price = 13.99m, ImageSource = "/Images/BobMarley2.jpg" },
                new Album { Id = 14, Title = "Island Mystic", Genre = Genre.Reggae, Artist = "Bob Marley", InStock = 12, NumberOfSongs = 15, Price = 17.99m, ImageSource = "/Images/BobMarley3.jpg" },
                new Album { Id = 15, Title = "Dirt", Genre = Genre.Grunge, Artist = "Alice In Chains", InStock = 4, NumberOfSongs = 10, Price = 13.99m, ImageSource = "/Images/AliceInChains.jpg" }
            };
        }
    }
}
