using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult High_school()
        {
            return View();
        }
        public ActionResult elementary_school()
        {
            return View();
        }
        
        public ActionResult junior_school()
        {
            return View();
        }

    }
}