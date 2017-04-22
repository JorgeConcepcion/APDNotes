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
        static List<Note> ANote = new List<Note>
        {
            new Note( "Bernard","Manuel","Yolo","4/3/2017", "4/5/2017","Submitted","4/3/2017"),
            new Note( "Fidel Castro","Manuel","Yolo","4/3/2017", "4/5/2017","Submitted","4/3/2017"),
            new Note( "Raulito la loca","Manuel","Yolo","4/3/2017", "4/5/2017","Submitted","4/3/2017"),
            new Note( "Esmerejildo","Manuel","Yolo","4/3/2017", "4/5/2017","Submitted","4/3/2017"),


        };
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
           
            _Note = ANote;
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
            _Note = ANote;


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