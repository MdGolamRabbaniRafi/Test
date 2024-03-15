using DAL.Interface;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repos
{
    internal class ProvideHelpRepo : IProvideHelp
    {
        private readonly DBContext db;

        public ProvideHelpRepo()
        {
            db = new DBContext();
        }

        public ProvideHelp Create(ProvideHelp obj)
        {
            db.ProvideHelps.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }


    }
}