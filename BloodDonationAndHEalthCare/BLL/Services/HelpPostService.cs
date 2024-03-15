using BLL.DTO;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace BLL.Services
{
    public class HelpPostService
    {
        public static HelpPostDTO AddHelpPostService(HelpPostDTO helppost , string token)
        {
            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var user = DataAccessFactory.UserData().ReadByEmail(UserEmail);
            helppost.UserId = user.UserId;
            if (helppost == null)
            {
                throw new ArgumentNullException(nameof(helppost));
            }
            var data = MapperClass.MapperHelpPost();
            var mapped = data.Map<HelpPost>(helppost);
            var helppostRepo = DataAccessFactory.HelpPostData().Create(mapped);
            var data2 = MapperClass.MapperHelpPost();
            var mapped2 = data2.Map<HelpPostDTO>(helppostRepo);

            return mapped2;
        }

        public static HelpPostDTO UpdateHelpPostService(int HelpPostId, HelpPostDTO helppost)
        {
            var data = MapperClass.MapperHelpPost();
            var existingUser = DataAccessFactory.HelpPostData().Read(HelpPostId);

            if (existingUser != null)
            {
                existingUser.Name = helppost.Name;
                existingUser.Phone = helppost.Phone;
                existingUser.Location = helppost.Location;
                existingUser.Problems = helppost.Problems;
                existingUser.Amount = helppost.Amount;
                var updateHelpPost = DataAccessFactory.HelpPostData().Update(existingUser);
                var data2 = MapperClass.MapperHelpPost();
                var mapped2 = data2.Map<HelpPostDTO>(updateHelpPost);
                return mapped2;
            }
            else
            {
                return null;
            }
        }



        public static HelpPostDTO GetHelpPost(int id)
        {
            var data = MapperClass.MapperHelpPost();
            var gethelpposts = DataAccessFactory.HelpPostData().Read(id);
            var mapped = data.Map<Post>(gethelpposts);
            var data2 = MapperClass.MapperHelpPost();
            var mapper2 = data2.Map<HelpPostDTO>(mapped);

            return mapper2;
        }
        public static List<HelpPostDTO> GetAllHelpPosts()
        {
            var data = MapperClass.MapperHelpPost();
            var allhelpPosts = DataAccessFactory.HelpPostData().Read();
            var mappedHelpPosts = data.Map<List<HelpPostDTO>>(allhelpPosts);

            return mappedHelpPosts;
        }
      
            public static int GetAllHelpPostsCount()
        {
            var data = MapperClass.MapperHelpPost();
            var allhelpPosts = DataAccessFactory.HelpPostData().Read();
            var mappedHelpPosts = data.Map<List<HelpPostDTO>>(allhelpPosts);
            int count = 0;
            foreach (var i in mappedHelpPosts)
            {
                count++;

            }

            return count;
        }
        public static bool DeleteHelpPostService(int HelpPostId)
        {
            var getHelpPost = DataAccessFactory.HelpPostData().Read(HelpPostId);

            if (getHelpPost != null)
            {
                var isDeleted = DataAccessFactory.HelpPostData().Delete(HelpPostId);

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
