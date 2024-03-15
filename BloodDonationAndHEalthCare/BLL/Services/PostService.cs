using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BLL.DTO;
using DAL.Interface;

namespace BLL.Services
{
    public class PostService
    {
        public static PostDTO AddPostService(PostDTO post,string token)
        {
            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var user = DataAccessFactory.UserData().ReadByEmail(UserEmail);
            post.UserId = user.UserId;
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            var data = MapperClass.MapperPost();
            var mapped = data.Map<Post>(post);
            var postRepo = DataAccessFactory.PostData().Create(mapped);
            var data2 = MapperClass.MapperPost();
            var mapped2 = data2.Map<PostDTO>(postRepo);

            return mapped2;
        }

        public static PostDTO UpdatePostService(int PostId, PostDTO post)
        {
            var data = MapperClass.MapperPost();
            var existingUser = DataAccessFactory.PostData().Read(PostId);

            if (existingUser != null)
            {
                existingUser.Name = post.Name;
                existingUser.BloodGroup = post.BloodGroup;
                existingUser.Phone = post.Phone;
                existingUser.Location = post.Location;
                existingUser.Problems = post.Problems;
                var updatePost = DataAccessFactory.PostData().Update(existingUser);
                var data2 = MapperClass.MapperPost();
                var mapped2 = data2.Map<PostDTO>(updatePost);
                return mapped2;
            }
            else
            {
                return null;
            }
        }


        public static PostDTO GetPost(int id)
        {
            var data = MapperClass.MapperPost();
            var getposts = DataAccessFactory.PostData().Read(id);
            var mapped = data.Map<Post>(getposts);
            var data2 = MapperClass.MapperPost();
            var mapper2 = data2.Map<PostDTO>(mapped);

            return mapper2;
        }
        public static List<PostDTO> GetAllPosts()
        {
            var data = MapperClass.MapperPost();
            var allPosts = DataAccessFactory.PostData().Read();
            var mappedPosts = data.Map<List<PostDTO>>(allPosts);

            return mappedPosts;
        }
        public static List<PostDTO> GetSingle(string token)
        {
            var UserEmail = DataAccessFactory.TokenData().SearchUserIdByToken(token);
            var user = DataAccessFactory.UserData().ReadByEmail(UserEmail);
            var ab = DataAccessFactory.PostData().ReadSingle(user.UserId);
            var data = MapperClass.MapperPost();
           
            var mappedPosts = data.Map<List<PostDTO>>(ab);

            return mappedPosts;
        }
        public static int GetAllUserPosts()
        {
            var data = MapperClass.MapperPost();
            var allPosts = DataAccessFactory.PostData().Read();
            var mappedPosts = data.Map<List<PostDTO>>(allPosts);
            int count= 0;
            foreach(var i in  mappedPosts)
            {
                count++;

            }

            return count;
        }
        public static bool DeletePostService(int PostId)
        {
            var getPost = DataAccessFactory.PostData().Read(PostId);

            if (getPost != null)
            {
                var isDeleted = DataAccessFactory.PostData().Delete(PostId);

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