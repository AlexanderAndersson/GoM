using GoM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoM.Controllers
    {
    public class SearchController : Controller
        {
        // GET: Search
        public ActionResult Index(string SearchText)
            {
            var model = GetAlbum();
            if(!string.IsNullOrEmpty(SearchText))
                {
                var result = model.Where(s => s.Artist.Contains(SearchText));
                return View(result.ToList());
                }
            return View(model);
            }

        public List<Album> GetAlbum()
            {
            var album = Database.Albums;

            return album;
            }


        public JsonResult AutoCompleteArtist(string term)
            {

            var result = (from r in Database.Albums
                          where r.Artist.ToLower().Contains(term.ToLower())
                          select new { r.Artist }).Distinct();
            return Json(result, JsonRequestBehavior.AllowGet);
            }


        }
    }