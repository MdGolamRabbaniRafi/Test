using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserAdminRepo : Repo, IRepo<UserAdmin, int, UserAdmin>, IAuth<bool>
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.UserAdmins.FirstOrDefault(u => u.Email.Equals(email) &&
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }
        public UserAdmin Create(UserAdmin obj)
        {
            db.UserAdmins.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.UserAdmins.Remove(ex);
            return db.SaveChanges() > 0;

        }

        public List<UserAdmin> Read()
        {
            return db.UserAdmins.ToList();
        }

        public UserAdmin Read(int id)
        {
            return db.UserAdmins.Find(id);
        }
        public UserAdmin ReadByEmail(string id)
        {
            return db.UserAdmins.FirstOrDefault(t => t.Email.Equals(id));

        }

        public UserAdmin Update(UserAdmin obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;

        }
    }
}
