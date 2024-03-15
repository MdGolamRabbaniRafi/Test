using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IFile<Type, ID>
    {
        Type Create(Type obj);
        Type ReadUserFile(ID id);
        Type ReadAdminFile(ID id);

    }
}
