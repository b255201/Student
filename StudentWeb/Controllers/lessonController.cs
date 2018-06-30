using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
    public class lessonController : Controller
    {
        // GET: lesson
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult High_school()
        {
            return View();
        }
    }
}