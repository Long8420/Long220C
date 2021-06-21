using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var cate = new CategoryDao();
            var model = cate.ListAll();
            return View(model);
        }
        // Yêu cầu tạo danh mục
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category cat)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                if (dao.GetByName(cat.Name) != null)
                {
                    SetAlert("Tên danh mục này đã tồn tại", "warning");
                    return RedirectToAction("Create", "Category");
                }
                long id = dao.Insert(cat);
                //Nếu insert thành công tức id >0
                if (id != 0)
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    SetAlert("Thêm danh mục không thành công", "error");
                }

            }
            return View("Index");
        }
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }

        }
        //3. Yêu cầu Cập nhật danh mục
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = new CategoryDao().ViewDetail(id);
            return View(cat);
        }
        [HttpPost]
        public ActionResult Edit(Category cat)
        {
            if (ModelState.IsValid)
            {
                var dao = new CategoryDao();
                var result = dao.Update(cat);
                if (result)
                {
                    SetAlert("Cập nhật thông tin danh mục", "success");
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Index");
        }
        //4. Yêu cầu Xóa danh mục
        public ActionResult Delete(int id)
        {
            new CategoryDao().Delete(id);
            return RedirectToAction("Index");
        }

    }
}
