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
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Writer(List<Note>_Note)
        {
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            User user = new User();
            user.Username = "Ramon";
            _Note = db.getWriterNotes(user);
            ViewBag.Username = _Note[0].Writer;
            return View(_Note);
        }
        [HttpPost]
        public ActionResult Writer(string username)
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Checker(List<Note> _Note)
        {
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            User user = new User();
            user.Username = "Pedro";
            _Note = db.getCheckerNotes(user);
            ViewBag.Username = _Note[0].Checker;
            return View(_Note);
        }
        [HttpPost]
        public ActionResult Checker(string username)
        {
            return View();
        }

      

    }
}