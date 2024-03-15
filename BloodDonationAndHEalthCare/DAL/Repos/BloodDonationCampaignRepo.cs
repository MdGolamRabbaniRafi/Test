using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using DAL.Interface;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repos
{
    internal class BloodDonationCampaignRepo : IBloodDonationCampaign
    {
        public BloodDonationCampaign Create(BloodDonationCampaign obj)
        {
            using (var db = new DBContext())
            {
                db.BloodDonationsCampaigns.Add(obj);
                if (db.SaveChanges() > 0) return obj;
                return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new DBContext())
            {
                var entity = db.BloodDonationsCampaigns.Find(id);
                if (entity != null)
                {
                    db.BloodDonationsCampaigns.Remove(entity);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public List<BloodDonationCampaign> Read()
        {
            using (var db = new DBContext())
            {
                return db.BloodDonationsCampaigns.ToList();
            }
        }

        public BloodDonationCampaign Read(int id)
        {
            using (var db = new DBContext())
            {
                return db.BloodDonationsCampaigns.Find(id);
            }
        }

        public BloodDonationCampaign Update(BloodDonationCampaign obj)
        {
            using (var db = new DBContext())
            {
                var existingEntity = db.BloodDonationsCampaigns.Find(obj.ID);
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



