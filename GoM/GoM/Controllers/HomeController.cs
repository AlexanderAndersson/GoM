﻿using GoM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var albums = (List<Album>)Session["Albums"];

            return View(albums.Take(4));
        }
    }
}
