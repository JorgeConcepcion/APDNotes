using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APDNotes.Models;


namespace APDNotes.Controllers
{
    public class UserController : Controller
    {


        /** Login *******************************************/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection Post)
        {
            string username = Post["Username"];
            string password = Post["Password"];

            User user = new User();
            user.Username = username;
            user.Password = password;
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            LoginResult loginResult =db.Login(user);
            if (loginResult.Exist)
            {
                
                if (loginResult.Position == "Analist" || loginResult.Position == "Office Staf")
                {
                    return RedirectToAction("Checker", user);   
                }
                else
                {
                    return RedirectToAction("Writer", user);
                }
            }
            return RedirectToAction("Login");
                   
        }


        /** Writer *******************************************/
        [HttpGet]
        public ActionResult Writer(User user)
        {

            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            LoginResult loginResult = db.Login(user);
            if (loginResult.Exist)
            {
                List<Note> _Note = db.getWriterNotes(user);
                ViewBag.Username = user.Username;
                return View(_Note);
            }
            else
            {
                return RedirectToAction("Login");
            }
           
        }
        [HttpPost]
        public ActionResult Writer(FormCollection Post)
        {
            return View();
        }


        /** Checker ******************************************/
        [HttpGet]
        public ActionResult Checker(User user)
        {
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            LoginResult loginResult = db.Login(user);
            if (loginResult.Exist)
            {
                List<Note> _Note = db.getCheckerNotes(user);
                ViewBag.Username = user.Username;
                return View(_Note);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult Checker(FormCollection Post)
        {
            return View();
        }


        /** NewNote ******************************************/
        [HttpGet]
        public ActionResult NewNote(string username)
        {
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            User user = new User();
            user.Username = "Ramon";
            List<Note> _Note = db.getWriterNotes(user);
            ViewBag.Username = _Note[0].Writer;

            return View();
        }
        [HttpPost]
        public ActionResult NewNote(FormCollection Post)
        {
            Note _Note = new Note(Post["Client"], Post["Writer"], "", Post["FirstDay"], Post["Last"], "Submitted", Post["DateSubmited"]);
            string FilePath = Post["NoteFile"];

            return View();
        }


    }
}