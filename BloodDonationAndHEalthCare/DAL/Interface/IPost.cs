using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IPost<Type, ID, RET>
    {
        RET Create(Type obj);
        List<RET> Read();
        List<RET> ReadSingle(ID id);
        Type Read(ID id);
        RET Update(Type obj);
        bool Delete(ID obj);
        string Read(string Email);
    }
}
