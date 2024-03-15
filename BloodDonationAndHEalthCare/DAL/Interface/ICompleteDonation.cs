using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface ICompleteDonation<Type, ID, RET, Time>
    {
        RET Create(Type obj, ID id);
        List<RET> Read();
        RET Read(ID id);
        Time Update(RET obj);
        bool Delete(ID obj);
        string Read(string Email);
        RET ReadByUserId(ID id);
    }
}