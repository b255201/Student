using StudentWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentWeb.Controllers
{
  
    public class DialogController : Controller
    {
        private Repository<StudentWeb.Models.LastNew> LastNew = new Repository<StudentWeb.Models.LastNew>();
        // GET: Dialog
        public ActionResult Index()
        {
            return View();
        }
        #region Login, 登入對話框
        /// <summary>
        ///  登入對話框
        /// </summary>
        /// <returns></returns>
        public ActionResult LastNewInfo(int Id = 1)
        {
            var q = LastNew.GetByID(Id);
            return PartialView("LastNewDialogPartial",q);
        }
        #endregion
    }
}