using GoM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoM.Controllers
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult Cart()
        {
            return View(Database.Account.ShoppingCart.Products);
        }

        [HttpPost]
        public ActionResult ChangeQuantity()
        {
            //Hämtar id:t på albumet och skapar sedan ett album utifrån det.
            int id = Convert.ToInt32(Request.Form.Get("id"));
            var album = Database.Albums.Where(a => a.Id == id).First();

            //Rensar varukorgen för de befintliga albumen av den typen
            Database.Account.ShoppingCart.Products.RemoveAll(p => p.Album == album);

            //Hämtar antalet från input
            int quantity = Convert.ToInt32(Request.Form.Get("quantity"));

            for (int i = 0; i < quantity; i++)
            {
                if (album.InStock > 0)
                {
                    var product = new Product { Album = album };
                    Database.Account.ShoppingCart.Products.Add(product);

                    album.InStock--;
                }
            }
          
            return RedirectToAction("Cart");
        }
    }
}