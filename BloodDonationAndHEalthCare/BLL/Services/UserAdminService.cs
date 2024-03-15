using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserAdminService
    {
        public static UserAdminDTO UpdateAdminUserService(UserAdminDTO admin)
        {
            var data = MapperClass.Mapped();
            var mapped = data.Map<UserAdmin>(admin);
            string hashedPassword = PasswordHasher.HashPassword(admin.Password);
            mapped.Password = hashedPassword; 
            var userRepo=DataAccessFactory.UserAdminData().Update(mapped);
            var data2 = MapperClass.Mapped();
            var mapped2 = data2.Map<UserAdminDTO>(userRepo);

            return mapped2;
        }
        public static bool Authenticate(string email, string pass)
        {
            string hashedPassword = PasswordHasher.HashPassword(pass);

            var data = DataAccessFactory.AuthData().Authenticate(email, hashedPassword);
            return data;
        }

        public static UserDTO AddUserService(UserDTO user, string token)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var adminEmailId = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var admin = DataAccessFactory.UserAdminData().ReadByEmail(adminEmailId);
            var data = MapperClass.MappedUser();
            var mapped = data.Map<User>(user);
            string hashedPassword = PasswordHasher.HashPassword(user.Password);
            mapped.Password = hashedPassword;
            mapped.AdminId = admin.Id;
            var userRepo = DataAccessFactory.UserData().Create(mapped);
            var data2 = MapperClass.MappedUser();
            var mapped2 = data2.Map<UserDTO>(userRepo);

            return mapped2;
        }


        public static UserAdminDTO AddAdminUserService(UserAdminDTO admin)
        {
            var data = MapperClass.Mapped();
            var mapped = data.Map<UserAdmin>(admin);
            string hashedPassword = PasswordHasher.HashPassword(admin.Password);
            mapped.Password = hashedPassword;
            var userRepo = DataAccessFactory.UserAdminData().Create(mapped);
            var data2 = MapperClass.Mapped();
            var mapped2 = data2.Map<UserAdminDTO>(userRepo);

            return mapped2;
        }

        public static UserDTO UpdateUserService(int userId, UserDTO user)
        {
            var data = MapperClass.MappedUser();
            var existingUser = DataAccessFactory.UserData().Read(userId);

            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.Password = PasswordHasher.HashPassword(user.Password);
                existingUser.BloodGroup = user.BloodGroup;
                var updatedUser = DataAccessFactory.UserData().Update(existingUser);
                var data2 = MapperClass.MappedUser();
                var mapped2 = data2.Map<UserDTO>(updatedUser);
                return mapped2;
            }
            else
            {
                return null;
            }
        }
        public static UserDTO GetUser(int UserId)
        {
            var data = MapperClass.MappedUser();
            var getusers = DataAccessFactory.UserData().Read(UserId);
            var mapped = data.Map<User>(getusers);
            var data2 = MapperClass.MappedUser();
            var mapper2 = data2.Map<UserDTO>(mapped);

            return mapper2;
        }
        public static bool DeleteUserService(int userId)
        {
            var getUser = DataAccessFactory.UserData().Read(userId);

            if (getUser != null)
            {
                var isDeleted = DataAccessFactory.UserData().Delete(userId);

                return isDeleted;
            }
            else
            {
                // User not found, handle accordingly (e.g., throw exception or return false)
                return false;
            }
        }


    }
}
