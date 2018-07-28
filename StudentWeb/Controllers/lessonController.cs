using PagedList;
using StudentWeb.Models;
using StudenWeb.Models.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace StudentWeb.Controllers
{
    public class lessonController : Controller
    {
        //IRepository<Models.JuniorHigh_School> JuniorHigh_School = new Repository<Models.JuniorHigh_School>();
        //StudentEntities db = new StudentEntities();
        private Repository<StudentWeb.Models.JuniorHigh_School> repo = new Repository<StudentWeb.Models.JuniorHigh_School>();
        // GET: lesson
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult High_school(int? page)
        {
            var pageNumber = page ?? 1;
            var q = repo.GetAll();
            return View(q.ToList().ToPagedList(pageNumber, 10));
        }
        public ActionResult test(int? page)
        {
            var pageNumber = page ?? 1;
            var q = repo.GetAll();
            return View(q.ToList().ToPagedList(pageNumber, 8));
        }
        public ActionResult GetImageFile(string fileName)
        {
            return File("C:/後台/StudentBack/StudentBack/Image/JuniorHigh_School/" + fileName, "image/png");
        }
    }
}