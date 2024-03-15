using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using System.Security.Policy;

namespace BLL.Services
{
    public class UserService
    {

        public static UserDTO AddUserService(UserDTO user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            var data = MapperClass.MappedUser();
            var mapped = data.Map<User>(user);
            string hashedPassword = PasswordHasher.HashPassword(user.Password);
            mapped.Password = hashedPassword;
            var userRepo = DataAccessFactory.UserData().Create(mapped);
            var data2 = MapperClass.MappedUser();
            var mapped2 = data2.Map<UserDTO>(userRepo);

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

        public static List<UserDTO> GetAllUser()
        {
            var data = MapperClass.MappedUser();
            var getusers = DataAccessFactory.UserData().Read();
            
            var mapper2 = data.Map<List<UserDTO>>(getusers);

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
        public static bool JoinBloodDonationCampaign(int userId, int campaignId)
        {
            var user = DataAccessFactory.UserData().Read(userId);
            var campaign = DataAccessFactory.BloodDonationCampaignData().Read(campaignId);

            if (user != null && campaign != null)
            {
                if (!user.JoinedCampaigns.Any(c => c.ID == campaignId))
                {
                    user.JoinedCampaigns.Add(campaign);


                    campaign.TotalMembersJoined++;


                    DataAccessFactory.UserData().Update(user);
                    DataAccessFactory.BloodDonationCampaignData().Update(campaign);

                    return true;
                }
            }

            return false;
        }
        





        /*       public static bool Authenticate(string email, string pass)
               {
                   string hashedPassword = PasswordHasher.HashPassword(pass);

                   var data = DataAccessFactory.AuthData().Authenticate(email, hashedPassword);
                   return data;
               }*/
    }
}
