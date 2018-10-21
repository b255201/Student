using StudentWeb.Models;
using StudenWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
    public class HighLessonController : Controller
    {
        private Repository<HighClass> repo = new Repository<HighClass>();
        // GET: HeighLesson
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(string coure)
        {
            var q = repo.GetAll().Where(i => i.Course == coure).OrderByDescending(c => c.Id);

            var id = q.Select(c => c.Id);
            var title = q.Select(c => c.title);
            return Json(new { id = id, title = title }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            var q = repo.GetAll().ToList();
            int totalLen = Convert.ToInt16(q.Count());
            var result = from Row in q
                         select new CourseViewModel
                         {
                             Id = Row.Id,
                             title = Row.title,
                             Description = Row.Description,
                             Image = Row.Image,
                             Course = Row.Course
                         };
            return Json(result);
        }

        #region 高中課程 Detail
        [HttpGet]
        public ActionResult Detail(int Id = 1)
        {
            var q = repo.GetByID(Id);
            ViewBag.Course = q.Course;
            ViewBag.img = q.Image;
            return View(q);
        }
        #endregion
        public ActionResult GetImageFile(string fileName)
        {
            //  return File("C:/後台/StudentBack/StudentBack/Image/Junior_Lesson/" + fileName, "image/png");
            return File("C:/back/Image/High_Lesson/" + fileName, "image/png");



        }
    }
}