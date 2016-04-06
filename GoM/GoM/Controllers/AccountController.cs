using GoM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoM.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Include = "Email, Password, FirstName, LastName, Address")]Account account)
        {
            if (ModelState.IsValid)
            {
                account.Id = Database.Accounts.Count() + 1;
                Database.Accounts.Add(account);

                Database.Account = account;

                return RedirectToAction("Index", "Products");
            }

            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn([Bind(Include = "Email, Password")]LogInViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (Database.Accounts.Any(a => a.Email == user.Email && a.Password == user.Password))
                {
                    var account = Database.Accounts.Where(a => a.Email == user.Email).First();
                    Database.Account = account;
                    return RedirectToAction("Index", "Products");
                }

                else
                {
                    return View();
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult LogOff()
        {
            Database.Account = null;

            return RedirectToAction("Index", "Products");
        }
    }
}
