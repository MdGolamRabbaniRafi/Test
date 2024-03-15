using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class CompleteDonationRepo : Repo, ICompleteDonation<Post, int, CompleteDonation, TimeSpan>
    {
        public CompleteDonation Create(Post obj, int DonerId)
        {
            CompleteDonation completeDonation = new CompleteDonation();
            completeDonation.Location = obj.Location;
            completeDonation.Id = DonerId;
            completeDonation.Phone = obj.Phone;
            completeDonation.Problems = obj.Problems;
            completeDonation.DonerId = DonerId;
            completeDonation.ReceverId = obj.UserId;
            completeDonation.DonationTime = DateTime.Now;
            completeDonation.NextDonationTime = DateTime.Now.AddMonths(4);
            //    completeDonation.RemainForNextDonationTime = completeDonation.NextDonationTime - completeDonation.DonationTime;
            db.CompleteDonations.Add(completeDonation);
            if (db.SaveChanges() > 0)
                return completeDonation;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.CompleteDonations.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<CompleteDonation> Read()
        {
            return db.CompleteDonations.ToList();
        }

        public CompleteDonation Read(int id)
        {
            return db.CompleteDonations.Find(id);
        }
        public CompleteDonation ReadByUserId(int id)
        {
            var completedonation = (from i in db.CompleteDonations where i.DonerId == id select i).FirstOrDefault();
            return completedonation;
        }

        public string Read(string Email)
        {
            throw new NotImplementedException();
        }

        public TimeSpan Update(CompleteDonation obj)
        {
            var ex = Read(obj.Id);
            TimeSpan remainTime = ex.NextDonationTime - DateTime.Now;

            //// Create a response object or dictionary
            //var response = new
            //{
            //    RemainingTime = remainTime.ToString(), // "c" format for constant (or customize as needed)
            //    Days = remainTime.Days,
            //    Hours = remainTime.Hours,
            //    Minutes = remainTime.Minutes,
            //    Seconds = remainTime.Seconds,
            //    Milliseconds = remainTime.Milliseconds
            //};

            //// Serialize to JSON
            //string jsonResponse = System.Text.Json.JsonSerializer.Serialize(response);
            return remainTime;
        }



    }
}