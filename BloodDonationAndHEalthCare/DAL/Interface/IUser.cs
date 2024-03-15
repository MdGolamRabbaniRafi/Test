using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUser<Type, ID, RET, StringType>
    {
        RET Create(Type obj);
        List<RET> Read();
        Type Read(ID id);
        RET Update(Type obj);
        bool Delete(ID obj);
        Type ReadByEmail(StringType Email);
        StringType Read(StringType id);
    }
}
