using BLL.DTO;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FileUploaderService
    {
       public static bool UploadFile(FileDTO fileInfo,string token)
       {
            if (fileInfo == null)
            {
                throw new ArgumentNullException(nameof(fileInfo));
            }
            var data = MapperClass.MapperFile();
            var mapped = data.Map<File>(fileInfo);
            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var user= DataAccessFactory.UserAdminData().ReadByEmail(UserEmail);
            if(user == null)
            {
             var user2 = DataAccessFactory.UserData().ReadByEmail(UserEmail);
                mapped.UserId = user2.UserId;
                mapped.UserType= user2.UserType;
            }
            else
            {
                mapped.UserId = user.Id;
                mapped.UserType = "Admin";
            }
          //  mapped.UserId = 
            var fileRepo = DataAccessFactory.FileData().Create(mapped);
            var data2 = MapperClass.MapperFile();
            var mapped2 = data2.Map<FileDTO>(fileRepo);
            if(mapped2 != null)
            {
                return true;
            }
            return false;
        }

        public static string GetFile(string token)
        {
            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var admin = DataAccessFactory.UserAdminData().ReadByEmail(UserEmail);
            if (admin == null)
            {
                var user = DataAccessFactory.UserData().ReadByEmail(UserEmail);

                if( user == null)
                {
                    return null;
                }
                else
                {
                    var file = DataAccessFactory.FileData().ReadUserFile(user.UserId);
                    return file.FileName;
                }
            }
            else 
            {
                var file = DataAccessFactory.FileData().ReadAdminFile(admin.Id);
                return file.FileName;
            }
            return null;
        }
    }
}
