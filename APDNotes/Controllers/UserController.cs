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

        /** Login *******************************************/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection Post)
        {
            string Username = Post["Username"];
            string Password = Post["Password"];



            User user = new User();

            /*      if (True)
                    {
                        if ()
                        {
                            return View("Writer(user)");
                        }
                        else if ()
                        {
                            return View("Checker(user)");
                        }
                        else
                        { }

                    }
           */      return View("please try again");
                   
            
            
        }


        /** Writer *******************************************/
        [HttpGet]
        public ActionResult Writer(User user)
        {
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            user = new User();
            user.Username = "Ramon";
            List<Note> _Note = db.getWriterNotes(user);
            ViewBag.Username = user.Username;
            return View(_Note);
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
            user = new User();
            user.Username = "Pedro";
            List<Note> _Note = db.getCheckerNotes(user);
            ViewBag.Username = user.Username;
            return View(_Note);
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