using ModelEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TestUngDung.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin

        public ActionResult Index()
        {
            if (Session[Constants.USER_SESSION] == null)
                return RedirectToAction("Index", "login");
            return View();

        }
        public ActionResult Logout()
        {
            Session[Constants.USER_SESSION] = null;
            return RedirectToAction("Index", "login");
        }
    }
}