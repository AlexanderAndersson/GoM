﻿using GoM.Models;
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
        public ActionResult Index(string SearchText)
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var albums = Database.Albums.Where(s => s.Artist.Contains(SearchText) || s.Genre.ToString() == (SearchText) || s.Title.Contains(SearchText));
                return View(albums.OrderBy(a => a.Id));
            }

            return View(Database.Albums.OrderBy(a => a.Id));

        }

        public ActionResult Details(int id)
        {
            var album = Database.Albums.Where(a => a.Id == id).First();

            return View(album);
        }

        public ActionResult Edit(int id)
        {
            var album = Database.Albums.Where(a => a.Id == id).First();

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                if (album.ImageSource == null)
                {
                    album.ImageSource = Database.Albums.Where(a => a.Id == album.Id).First().ImageSource;
                }

                Database.Albums.RemoveAll(a => a.Id == album.Id);
                Database.Albums.Add(album);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            Database.Albums.RemoveAll(a => a.Id == id);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                if (album.ImageSource == null)
                {
                    album.ImageSource = "/Images/Default.png";
                }

                album.Id = Database.Albums.Count + 1;

                Database.Albums.Add(album);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddToCart()
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

        [HttpPost]
        public ActionResult AddToCartQuantity()
        {
            //Hämtar id:t på albumet och hämtar sedan ett album från "databasen" utifrån det.
            int id = Convert.ToInt32(Request.Form.Get("id"));
            var album = Database.Albums.Where(a => a.Id == id).First();

            //Hämtar antalet från input
            int quantity = Convert.ToInt32(Request.Form.Get("quantity"));

            //Om det inte finns en inloggad användare...
            if (Database.Account == null)
            {
                //så skickar vi användaren till logga in/registrera-sidan
                return RedirectToAction("LogInRegister", "Account");
            }

            if (Database.Account.ShoppingCart.Products.Any(p => p.Album.Id == id))
            {
                if (quantity == 0)
                {
                    Database.Account.ShoppingCart.Products.RemoveAll(p => p.Album == album);
                }

                else
                {
                    Database.Account.ShoppingCart.Products.Where(p => p.Album == album).First().Quantity = quantity;
                }
            }

            else
            {
                if (quantity != 0)
                {
                    Database.Account.ShoppingCart.Products.Add(new Product { Album = album, Quantity = quantity });
                }
            }


            return RedirectToAction("Details", new { id });
        }
    }
}