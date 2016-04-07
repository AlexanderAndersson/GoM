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

        public ActionResult AddToCart(int id)
        {
            //var account = Database.Accounts.Where(a => a.Id == 1).First();
            var album = Database.Albums.Where(a => a.Id == id).First();          

            if (album.InStock > 0)
            {
                Database.Account.ShoppingCart.Products.Add(new Product { Album = album });
                album.InStock--;
            }

            return RedirectToAction("Index");
        }
    }
}