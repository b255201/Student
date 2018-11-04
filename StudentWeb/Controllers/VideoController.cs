using PagedList;
using StudentBack.Models.Models;
using StudentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
    public class VideoController : Controller
    {
        IRepository<Video> Videos = new Repository<Video>();
        StudentEntities db = new StudentEntities();
     
        // GET: Video
        public ActionResult Index(int? page)
        {
            //最新消息
            var pageNumber = page ?? 1;
            var q = Videos.GetAll().OrderByDescending(c => c.Id);
            ViewBag.Count = q.First().Id.ToString();
            return View(q.ToList().ToPagedList(pageNumber, 10));
        }
    }
}