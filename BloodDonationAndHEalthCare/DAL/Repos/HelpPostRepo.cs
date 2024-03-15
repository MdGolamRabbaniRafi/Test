using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class HelpPostRepo : Repo, IHelpPost<HelpPost, int, HelpPost>
    {
        public HelpPost Create(HelpPost obj)
        {
            db.HelpPosts.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.HelpPosts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<HelpPost> Read()
        {
            return db.HelpPosts.ToList();
        }

        public HelpPost Read(int id)
        {
            return db.HelpPosts.Find(id);
        }

        public string Read(string Email)
        {
            throw new NotImplementedException();
        }

        public HelpPost Update(HelpPost obj)
        {
            var ex = Read(obj.HelpPostId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
    }
}
