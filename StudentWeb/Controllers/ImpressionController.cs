using PagedList;
using StudentWeb.Models;
using StudenWeb.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
    public class ImpressionController : Controller
    {
        private Repository<StudentWeb.Models.StudentImpression> ScholarShip = new Repository<StudentWeb.Models.StudentImpression>();
        // GET: Impression
        public ActionResult Index(int? page)
        {
            //最新消息
            var pageNumber = page ?? 1;
            var L = ScholarShip.GetAll().OrderByDescending(c => c.Id);
            return View(L.ToList().ToPagedList(pageNumber, 10));
        }
        public ActionResult GetImageImpression(string fileName)
        {
            //  return File("C:/後台/StudentBack/StudentBack/Image/elementary_Book/" + fileName, "image/png");
            return File("C:/back/Image/StudentImpression/" + fileName, "image/png");
        }
    }
}