﻿using GoM.Models;
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
                var payment = new Payment
                {
                    CardNumber = user.CardNumber,
                    ExpirationMonth = user.ExpirationMonth,
                    ExpirationYear = user.ExpirationYear,
                    CvcNumber = user.CvcNumber,
                    Account = Database.Account
                };

                foreach (var product in Database.Account.ShoppingCart.Products)
                {
                    var album = Database.Albums.Where(a => a.Id == product.Album.Id).First();
                    album.InStock -= product.Quantity;
                }

                Database.Account.ShoppingCart = new ShoppingCart();

                return View("Success", payment);
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
                //var product = new Product { Album = album, Quantity = quantity };
                Database.Account.ShoppingCart.Products.Where(p => p.Album == album).First().Quantity = quantity;
            }

            return RedirectToAction("Cart");
        }
    }
}