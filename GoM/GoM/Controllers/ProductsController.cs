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
        public ActionResult Index(string SearchText, string sortOrder)
        {
            ViewBag.CurrentSort = sortOrder;

            var albums = (List<Album>)Session["Albums"];

            if (!string.IsNullOrEmpty(SearchText))
            {
                albums = albums.Where(s => s.Artist.Contains(SearchText) || s.Genre.ToString() == (SearchText) || s.Title.Contains(SearchText)).ToList();
                
                return View(albums.OrderBy(a => a.Id));
            }

            ViewBag.ArtistName = sortOrder == "Artist" ? "ArtistName_Descending" : "Artist";
            ViewBag.YearSort = sortOrder == "Price" ? "Price_Descending" : "Price";

            var artist = from a in albums
                         select a;
            switch (sortOrder)
            {
                case "Artist":
                    artist = artist.OrderBy(s => s.Artist);
                    return View(artist);
                case "ArtistName_Descending":
                    artist = artist.OrderByDescending(s => s.Artist);
                    return View(artist);
                case "Price":
                    artist = artist.OrderBy(s => s.Price);
                    return View(artist);
                case "Price_Descending":
                    artist = artist.OrderByDescending(s => s.Price);
                    return View(artist);
                default:  // Name ascending 
                    artist = artist.OrderBy(s => s.Id);
                    return View(artist);

            }


        }

        public ActionResult Details(int id)
        {
            var albums = (IEnumerable<Album>)Session["Albums"];
            var album = albums.Where(a => a.Id == id).First();

            return View(album);
        }

        public ActionResult Edit(int id)
        {
            var albums = (IEnumerable<Album>)Session["Albums"];
            var album = albums.Where(a => a.Id == id).First();

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            var albums = (List<Album>)Session["Albums"];

            if (ModelState.IsValid)
            {
                if (album.ImageSource == null)
                {
                    album.ImageSource = albums.Where(a => a.Id == album.Id).First().ImageSource;
                }

                albums.RemoveAll(a => a.Id == album.Id);
                albums.Add(album);

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            var albums = (List<Album>)Session["Albums"];
            albums.RemoveAll(a => a.Id == id);

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

                var albums = (List<Album>)Session["Albums"];
                album.Id = albums.Count + 1;

                albums.Add(album);

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddToCart()
        {
            //Hämtar id:t på albumet och hämtar sedan ett album från "databasen" utifrån det.
            int id = Convert.ToInt32(Request.Form.Get("id"));

            var albums = (IEnumerable<Album>)Session["Albums"];
            var album = albums.Where(a => a.Id == id).First();

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

            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        public ActionResult AddToCartQuantity()
        {
            //Hämtar id:t på albumet och hämtar sedan ett album från "databasen" utifrån det.
            int id = Convert.ToInt32(Request.Form.Get("id"));

            var albums = (IEnumerable<Album>)Session["Albums"];
            var album = albums.Where(a => a.Id == id).First();

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
        public JsonResult AutoCompleteArtist(string term)
        {
            var albums = (IEnumerable<Album>)Session["Albums"];

            var result = (from r in albums
                          where r.Artist.ToLower().Contains(term.ToLower()) || r.Genre.ToString() == term || r.Title.Contains(term)
                          select new { r.Artist, r.Title, r.Price }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}