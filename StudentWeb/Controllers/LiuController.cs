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
    public class LiuController : Controller
    {
        IRepository<FreeTrail> FreeTrails = new Repository<FreeTrail>();
        IRepository<EDM> EDMS = new Repository<EDM>();
        StudentEntities db = new StudentEntities();
        private Repository<Activity_Message> Activity_Message = new Repository<Activity_Message>();
        private Repository<StudentWeb.Models.LastNew> LastNew = new Repository<StudentWeb.Models.LastNew>();
        // GET: Liu
        public ActionResult Index(int? page)
        {
            //活動消息
            var q = Activity_Message.GetAll().OrderByDescending(c=>c.Id);
            ViewBag.Activity = q.ToList();
            //最新消息
            var pageNumber = page ?? 1;
            var L = LastNew.GetAll().OrderByDescending(c => c.Id); 
            return View(L.ToList().ToPagedList(pageNumber, 10));
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
                f.Memo = form["Memo"];
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

        public ActionResult Contact(string Name,string SchoolName,string Email,string Phone,string Course, string LocalPhone,string Memo) 
        {
            try
            {
                FreeTrail f = new FreeTrail();

                var q = db.FreeTrails.ToList();
                var result = (from Row in q
                              select new LessonViewModel
                              {
                                  SeqID = Row.SeqID
                              }).OrderByDescending(x => x.SeqID);
                var MaxId = int.Parse(result.First().SeqID.ToString());
                int seq = MaxId + 1;
                f.SeqID = seq;
                f.Name = Name;
                f.SchoolName = SchoolName;
                f.Email = Email;
                f.Phone = Phone;
                f.LocalPhone = LocalPhone;
                f.Course = Course;
                f.CreateTime = DateTime.Now;
                f.Memo = Memo;
                db.FreeTrails.Add(f);
                db.SaveChanges();
                return Json(new { Status = "0", Message = "" });
            }
            catch (Exception err)
            {
                return Json(new { Status = "1", Message = "" + err });
                throw;
            }
        }

        public ActionResult EDM(string EDM)
        {
            try
            {
                EDM f = new EDM();              
                f.Email = EDM;
                db.EDMs.Add(f);
                db.SaveChanges();
                return Json(new { Status = "0", Message = "" });
            }
            catch (Exception err)
            {
                return Json(new { Status = "1", Message = "" + err });
                throw;
            }

        }


        public ActionResult GetImageFile(string fileName)
        {
            //  return File("C:/後台/StudentBack/StudentBack/Image/LiuIndex/" + fileName, "image/png");
            return File("C:/back/Image/LiuIndex/" + fileName, "image/png");
        }


    }
}