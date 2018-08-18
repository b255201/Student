using StudentWeb.Models;
using StudenWeb.ViewModel;
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
        private Repository<Activity_Message> Activity_Message = new Repository<Activity_Message>();
        // GET: Liu
        public ActionResult Index()
        {
            var q = Activity_Message.GetAll();
            //var q = db.FreeTrails.ToList();       
            return View(q.ToList());
        }
        [HttpPost]
        public ActionResult InsertContact(FormCollection form)
        {
            try
            {
                FreeTrail f = new FreeTrail();
    
                var q = db.FreeTrails.ToList();
                var result = (from Row in q
                              select new LessonViewModel
                              {
                                  SeqID =Row.SeqID
                              }).OrderByDescending(x => x.SeqID);
                var MaxId = int.Parse(result.First().SeqID.ToString());
                int seq = MaxId + 1;
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
        public ActionResult GetImageFile(string fileName)
        {
             return File("C:/後台/StudentBack/StudentBack/Image/LiuIndex/" + fileName, "image/png");
           // return File("C:/back/Image/LiuIndex/" + fileName, "image/png");
        }
    }
}