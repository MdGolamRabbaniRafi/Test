using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUser<User, int ,User, string>, IAuth<bool>
    {
        public bool Authenticate(string Email, string Password)
        {
            var data = db.Users.FirstOrDefault(u => u.Email.Equals(Email) &&
            u.Password.Equals(Password));
            if (data != null) return true;
            return false;
        }

        public User Create(User obj)
        {
            db.Users.Add(obj); 
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Users.Remove(ex);
           return  db.SaveChanges()>0;
        }

        public List<User> Read()
        {
            return db.Users.ToList();
        }

        public User Read(int id)
        {
            return db.Users.Find(id);
        }

        public User Update(User obj)
        {
           var ex = Read(obj.UserId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges() > 0) return obj;
            return null;

        }
        public string Read(string email)
        {
            var user = (from u in db.Users where u.Email.Equals(email) select u).SingleOrDefault();
            string type=user.UserType.ToString();
            return type;
        }
        public User ReadByEmail(string email)
        {
            var user = (from u in db.Users where u.Email.Equals(email) select u).SingleOrDefault();
            if(user== null) return null;
            return user;

        }
    }
}
