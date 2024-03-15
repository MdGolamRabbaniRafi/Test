using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using DAL.Interface;
using DAL.Models;

namespace DAL.Repos
{
    internal class DonationRepo : Repo, IDonation
    {
        public Donation Create(Donation obj)
        {
            using (var db = new DBContext())
            {
                db.Donations.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DBContext())
            {
                var entity = db.Donations.Find(id);
                if (entity != null)
                {
                    db.Donations.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
       
        public List<Donation> Read()
        {
            using (var db = new DBContext())
            {
                return db.Donations.ToList();
            }
        }
        public List<Donation> ReadAccept()
        {
            
          
            var a = (from b in db.Donations where b.IsApproved == true select b).ToList();
                
          
            return a;
        }

        public Donation Read(int id)
        {
            using (var db = new DBContext())
            {
                return db.Donations.Find(id);
            }
        }

        public Donation Update(Donation obj)
        {
            using (var db = new DBContext())
            {
                var existingEntity = db.Donations.Find(obj.Id);
                if (existingEntity != null)
                {
                    db.Entry(existingEntity).CurrentValues.SetValues(obj);
                    db.SaveChanges();
                    return obj;
                }
                return null;
            }
        }
    }
}

