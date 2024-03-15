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
    public class CompleteDonationService
    {
        public static CompleteDonationDTO AddCompleteDonationService(int postId, string token)
        {
            var userEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var donerId = DataAccessFactory.UserData().ReadByEmail(userEmail);
            var post = DataAccessFactory.PostData().Read(postId);
            var completeDonation = DataAccessFactory.CompleteDonationData().Create(post, donerId.UserId);
            var DeletePost = DataAccessFactory.PostData().Delete(postId);
            if (!DeletePost)
            {
                return null;
            }
            var data2 = MapperClass.MapperCompleteDonation();
            var mapped2 = data2.Map<CompleteDonationDTO>(completeDonation);

            return mapped2;
        }

        public static TimeSpan RemainTime(string token)
        {
            var userEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var userId = DataAccessFactory.UserData().ReadByEmail(userEmail);
            var completeDonation = DataAccessFactory.CompleteDonationData().ReadByUserId(userId.UserId);
            var remain = DataAccessFactory.CompleteDonationData().Update(completeDonation);
            return remain;
        }
    }
}