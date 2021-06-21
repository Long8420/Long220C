using ModelEF;
using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User

        public ActionResult Index()
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult CreateUser()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserAccount model)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();

                var pass = model.Password;
                model.Password = pass;
                string result = dao.Insert(model);
                if (!string.IsNullOrEmpty(result))
                {

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Tao không thành công");
                }
            }
            return View();
        }
       
    }
}
        


   