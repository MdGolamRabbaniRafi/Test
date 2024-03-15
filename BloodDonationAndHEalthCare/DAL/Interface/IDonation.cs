using DAL.Models;
using System.Collections.Generic;
using System.Security.Policy;

namespace DAL.Interface
{
    public interface IDonation
    {
        Donation Create(Donation obj);
        List<Donation> Read();
        Donation Read(int id);
        List<Donation> ReadAccept();
        Donation Update(Donation obj);
        bool Delete(int id);
    }
}

