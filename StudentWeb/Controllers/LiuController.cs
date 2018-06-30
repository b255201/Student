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
        IRepository<FreeTrail> FreeTrails = new Repository<FreeTrail>();
        StudentEntities db = new StudentEntities();
        // GET: Liu
        public ActionResult Index()
        {
           // var q = db.FreeTrails.ToList();       
            return View();
        }
        [HttpPost]
        public ActionResult InsertContact(FormCollection form)
        {
            try
            {
                FreeTrail f = new FreeTrail();
                var q = db.FreeTrails.ToList();
                int seq = q.Count() + 1;
                f.SeqID = seq;
                f.Name = form["Name"];
                f.SchoolName = form["SchoolName"];
                f.Email = form["Email"];
                f.Phone = form["Phone"];
                f.LocalPhone = form["LocalPhone"];
                f.Course = form["Course"];
                f.CreateTime = DateTime.Now;
                db.FreeTrails.Add(f);
                db.SaveChanges();
                return Json(new { Status = "0", Message = "" });
            }
            catch (Exception err)
            {
                return Json(new { Status = "1", Message = ""+err });
                throw;
            }
        
        }
    }
}