using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IEmail
    {
        void SendEmail(string to, string subject, string body);
    }
}
