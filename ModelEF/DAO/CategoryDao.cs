using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        NguyenHuynhPhiLongContext db = null;

        public CategoryDao()
        {
            db = new NguyenHuynhPhiLongContext();
        }
        //Lấy ra list danh mục để tạo drop cho loại sản phẩm bên bảng spham
        public List<Category> ListAll()
        {
            return db.Category.ToList();
        }
        //1. Phương thức thêm mới danh mục
        public long Insert(Category entity)
        {
            db.Category.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        //2. Phương thức lấy ra tên danh mục
        public Category GetByName(string name)
        {
            return db.Category.SingleOrDefault(x => x.Name == name);
        }

        //3. Phương thức cập nhật thông tin danh mục
        public bool Update(Category entity)
        {
            try
            {
                var cat = db.Category.Find(entity.ID);
                cat.Name = entity.Name;
                cat.Description = entity.Description;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //4. Phương thức hiện lấy Id để cập nhật thông tin danh mục
        public Category ViewDetail(int id)
        {
            return db.Category.Find(id);
        }
        //5. Phương thức xóa danh mục
        public bool Delete(int id)
        {

            var cat = db.Category.Find(id);
            db.Category.Remove(cat);
            db.SaveChanges();
            return true;

        }
    }
}     

