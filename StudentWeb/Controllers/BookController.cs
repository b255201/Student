using PagedList;
using StudentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
  
    public class BookController : Controller
    {
        private Repository<elementary_Book> elementary = new Repository<elementary_Book>();
        private Repository<High_Book> Heigh = new Repository<High_Book>();
        private Repository<junior_Book> junior = new Repository<junior_Book>();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        #region 高中書籍
        public ActionResult High_school(int? page)
        {
            var pageNumber = page ?? 1;
            var q = Heigh.GetAll();
            return View(q.ToList().ToPagedList(pageNumber, 9));          
        }

        #endregion
        #region 高中書籍 Detail
        public ActionResult High_schoolDetail(int Id = 1)
        {
            var q = Heigh.GetByID(Id);
            return View(q);
        }
        #endregion

        public ActionResult GetImageHighBook(string fileName)
        {
            // return File("C:/後台/StudentBack/StudentBack/Image/High_Book/" + fileName, "image/png");
            return File("C:/back/Image/High_Book/" + fileName, "image/png");
        }

        #region 國小書籍
        public ActionResult elementary_school(int? page)
        {
            var pageNumber = page ?? 1;
            var q = elementary.GetAll();
            return View(q.ToList().ToPagedList(pageNumber, 9));
        }
        #endregion

        #region 國小書籍 Detail
        public ActionResult elementary_schoolDetail(int Id=1)
        {
         
            var q = elementary.GetByID(Id);
            return View(q);
        }
        #endregion

        public ActionResult GetImageelementaryBook(string fileName)
        {
          //  return File("C:/後台/StudentBack/StudentBack/Image/elementary_Book/" + fileName, "image/png");
            return File("C:/back/Image/elementary_Book/" + fileName, "image/png");
        }

        #region 國中書籍
        public ActionResult junior_school(int? page)
        {
            var pageNumber = page ?? 1;
            var q = junior.GetAll();
            return View(q.ToList().ToPagedList(pageNumber, 9));
        }
        #endregion

        #region 國中書籍 Detail
        public ActionResult junior_schoolDetail(int Id = 1)
        {
            var q = junior.GetByID(Id);
            return View(q);
        }
        #endregion

        public ActionResult GetImagejuniorBook(string fileName)
        {
            // return File("C:/後台/StudentBack/StudentBack/Image/junior_Book/" + fileName, "image/png");
            return File("C:/back/Image/junior_Book/" + fileName, "image/png");
        }
    }
}