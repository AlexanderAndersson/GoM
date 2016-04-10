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

        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Payment(CheckoutViewModel user)
        {
            if (ModelState.IsValid)
            {
                var viewingAccount = new Account { FirstName = Database.Account.FirstName, LastName = Database.Account.LastName, Email = Database.Account.Email, Address = Database.Account.Address, ShoppingCart = Database.Account.ShoppingCart };

                var cardNumber = new String('*', 12) + user.CardNumber.ToString().Substring(12);

                var payment = new Payment
                {
                    CardNumber = cardNumber,
                    ExpirationMonth = user.ExpirationMonth,
                    ExpirationYear = user.ExpirationYear,
                    CvcNumber = user.CvcNumber,
                    Account = viewingAccount
                };

                foreach (var product in Database.Account.ShoppingCart.Products)
                {
                    var album = Database.Albums.Where(a => a.Id == product.Album.Id).First();
                    album.InStock -= product.Quantity;
                }

                Database.Account.ShoppingCart = new ShoppingCart();

                return View("Receipt", payment);
            }

            return View();
        }

        [HttpPost]
        public ActionResult ChangeQuantity()
        {
            //Hämtar id:t på albumet och skapar sedan ett album utifrån det.
            int id = Convert.ToInt32(Request.Form.Get("id"));
            var album = Database.Albums.Where(a => a.Id == id).First();

            //Hämtar antalet från input
            int quantity = Convert.ToInt32(Request.Form.Get("quantity"));

            if (quantity == 0)
            {
                Database.Account.ShoppingCart.Products.RemoveAll(p => p.Album == album);
            }

            else
            {
                Database.Account.ShoppingCart.Products.Where(p => p.Album == album).First().Quantity = quantity;
            }

            return RedirectToAction("Cart");
        }
    }
}