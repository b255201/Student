using StudentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
    public class LiuController : Controller
    {
        IRepository<FreeTrail> dishCategories = new Repository<FreeTrail>();
        StudentEntities db = new StudentEntities();
        // GET: Liu
        public ActionResult Index()
        {
            var q = db.FreeTrails.ToList();
           
            return View(q);
        }
    }
}