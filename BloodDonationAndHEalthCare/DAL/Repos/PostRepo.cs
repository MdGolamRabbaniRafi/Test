using DAL.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class PostRepo : Repo, IPost<Post, int, Post>
    {
        public Post Create(Post obj)
        {
            db.Posts.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Posts.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Post> Read()
        {
           return db.Posts.ToList();
        }
       

        public Post Read(int id)
        {
            return db.Posts.Find(id);
        }

        public string Read(string Email)
        {
            throw new NotImplementedException();
        }

        public Post Update(Post obj)
        {
            var ex = Read(obj.PostId);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public List<Post> ReadSingle(int id)
        {
            try
            {
                var posts = db.Posts.Where(post => post.UserId == id).ToList();
                return posts;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                Console.WriteLine("An error occurred: " + ex.Message);
                return new List<Post>(); // Return an empty list or handle the error in a way that makes sense for your application
            }
        }
    }
    }
