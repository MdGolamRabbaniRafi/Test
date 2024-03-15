using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IToken<Type, ID, RET, A>
    {
        RET Create(Type obj);
        List<RET> Read();
        Type Read(ID id);
        Type ReadByUserId(ID id);

        RET Update(Type obj);
        A Delete(ID id);
        ID SearchUserIdByToken(ID token);
        Type Search(ID Email);
    }
}
