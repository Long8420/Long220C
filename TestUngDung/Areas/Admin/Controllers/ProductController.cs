using ModelEF.DAO;
using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            var product = new ProductDao();
            var model = product.ListAll();
            return View(model);
        }
        //2. Yêu cầu tạo mới sản phẩm
        [HttpGet]
        public ActionResult CreateProduct()
        {
            SetViewBag();
            return View();
        }

        //Yêu cầu hiện droplist
        public void SetViewBag(long? selectedId = null)
        {
            var dao = new CategoryDao();
            ViewBag.ProductType = new SelectList(dao.ListAll(), "ID", "Name", selectedId);
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateProduct(Product pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                if (dao.GetByName(pro.Name) != null)
                {
                    SetAlert("Tên sản phẩm này đã tồn tại", "warning");
                    return RedirectToAction("Create", "Product");
                }
                long id = dao.Insert(pro);
                //Nếu insert thành công tức id >0
                if (id != 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    SetAlert("Thêm sản phẩm không thành công", "error");
                    return RedirectToAction("Index", "Product");
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
        public ActionResult Detail(int id)
        {
            var detailView = new ProductDao().Find(id);
            return View(detailView);
        }
        //4. Yêu cầu cập nhật sản phẩm
        public ActionResult EditProduct(int id)
        {
            var cat = new ProductDao().ViewDetail(id);
            SetViewBag(cat.ProductType);
            return View(cat);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProduct(Product pro)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();

                var result = dao.Update(pro);

                if (result)
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật sản phẩm không thành công");
                }
            }
            SetViewBag(pro.ProductType);
            return View("Index");
        }
        //5. Yêu cầu xóa sản phẩm
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}

   