using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    {
        private NguyenHuynhPhiLongContext db;
        public ProductDao()
        {
            db = new NguyenHuynhPhiLongContext();

        }//đổ danh sách vào bảng
        public List<Product> ListAll()
        {
            return db.Product.ToList();
        }
        //2. Phương thức thêm mới sản phẩm
        public long Insert(Product entity)
        {
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;
        } //3. Phương thức lấy ra tên sản phẩm
        public Product GetByName(string name)
        {
            return db.Product.SingleOrDefault(x => x.Name == name);
        }

    
        //4. Phương thức cập nhật thông tin sản phẩm
        public bool Update(Product entity)
        {
            try
            {
                var pro = db.Product.Find(entity.ID);
                pro.Name = entity.Name;
                pro.UnitCost = entity.UnitCost;
                pro.Quantity = entity.Quantity;
                pro.Image = entity.Image;
                pro.Description = entity.Description;
                pro.Status = entity.Status;
                pro.ProductType = entity.ProductType;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
       
        //5. Phương thức tìm sản phẩm theo id để xem chi tiết sản phẩm
        public Product Find(long id)
        {
            return db.Product.Find(id);
        }
        //Phương thức hiện láy id để cập nhập thông tin sản phẩm;
        public Product ViewDetail(int id)
        {
            return db.Product.Find(id);
        }

        //5. Phương thức xóa sản phẩm
        public bool Delete(int id)
        {
            try
            {
                var pro = db.Product.Find(id);
                db.Product.Remove(pro);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


    }
}


