using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APDNotes.Model;

namespace APDNotes.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username)
        {
            return View();
        }

        public ActionResult Writer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Writer(string username)
        {
            
            return View();
        }
        
        public ActionResult Checker()
        {
            ViewBag.Note = new List<Note>();
            return View();
        }
        [HttpPost]
        public ActionResult Checker(string username)
        {
            return View();
        }

      

    }
}