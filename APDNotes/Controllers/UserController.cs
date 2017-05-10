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
                ViewBag.Password = user.Password;

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
        public ActionResult NewNote(string username, string password)
        {
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            User user = new User();
            user.Username = username;
            user.Password = password;
            LoginResult loginResult = db.Login(user);
            if (loginResult.Exist)
            {
                ViewBag.Username = username;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        

         
        
        [HttpPost]
        public ActionResult NewNote(FormCollection Post)
        {
            Note _Note = new Note(Post["Client"], Post["Writer"], "", Post["FirstDay"], Post["LastDay"], "Submited", ((DateTime.Today.Year)+"-"+(DateTime.Today.Month)+"-"+(DateTime.Today.Day)) );
            string FilePath = Post["NoteFile"];
            DatabaseManager db = new DatabaseManager("apddatabase.cskqyrkvaybu.us-west-2.rds.amazonaws.com", "erneplopez", "uclv11**", "NoteManager");
            db.AddNote(_Note);
            AWSS3Manager aws = new AWSS3Manager("apdnotes");
            aws.UploadFile(Post["Writer"] + "/" + Post["Client"] + "/" + Post["FirstDay"] + "-" + Post["LastDay"], FilePath);
            User user = new User();
            user.Username = Post["Writer"];
            user.Password = Post["Password"];
            return RedirectToAction("Writer",user);
        }


    }
}