using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private NguyenHuynhPhiLongContext db;
        public UserDao()
        {
            db = new NguyenHuynhPhiLongContext();

        }
        public int login(string user, string pass)
        {
            var result = db.UserAccount.SingleOrDefault(x => x.Username.Contains(user) && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else { return 1; }
        }
        // Tạo tài khoản vô data
        public string Insert(UserAccount entityuser)
        {
            db.UserAccount.Add(entityuser);
            db.SaveChanges();
            return entityuser.Username;
        }

        //hiển thị danh sách use
        public List<UserAccount> ListAll()
        {
            return db.UserAccount.ToList();
        }
     

    }
}
        