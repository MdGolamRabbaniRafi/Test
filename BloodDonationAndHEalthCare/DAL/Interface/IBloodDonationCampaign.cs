using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBloodDonationCampaign
    {
        BloodDonationCampaign Create(BloodDonationCampaign obj);
        List<BloodDonationCampaign> Read();
        BloodDonationCampaign Read(int id);
        BloodDonationCampaign Update(BloodDonationCampaign obj);
        bool Delete(int id);
    }
}