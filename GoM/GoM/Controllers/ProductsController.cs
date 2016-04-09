using GoM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoM.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View(Database.Albums);
        }

        [HttpPost]
        public ActionResult AddToCart(/*int id*/)
        {
            //Hämtar id:t på albumet och hämtar sedan ett album från "databasen" utifrån det.
            int id = Convert.ToInt32(Request.Form.Get("id"));
            var album = Database.Albums.Where(a => a.Id == id).First();

            //Om albumet har behållning...
            if (album.InStock > 0)
            {
                //och om det inte finns en inloggad användare...
                if (Database.Account == null)
                {
                    //så skickar vi användaren till logga in/registrera-sidan
                    return RedirectToAction("LogInRegister", "Account");
                }

                //Om användaren inte redan har albumet i sin varukorg...
                if (!Database.Account.ShoppingCart.Products.Any(p => p.Album == album))
                {
                    //så skapar vi en ny produkt med albumet och lägger i varukorgen.
                    Database.Account.ShoppingCart.Products.Add(new Product { Album = album, Quantity = 1 });
                }

                //Annars om kvantiteten användaren har av produkten är mindre än behållningen av albumet.
                else if (Database.Account.ShoppingCart.Products.Where(p => p.Album == album).First().Quantity < album.InStock)
                {
                    //så ökar vi kvantiteten med 1...
                    Database.Account.ShoppingCart.Products.Where(p => p.Album == album).First().Quantity++;
                }
            }

            return RedirectToAction("Index");
        }
    }
}