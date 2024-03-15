using BLL.DTO;
using BLL.DTOs;
using BLL.Services;
using BloodDonationAndHEalthCare.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonationAndHEalthCare.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PostController : ApiController
    {
        [Logged]
        [HttpPost]
        [Route("api/post/add")]
        public HttpResponseMessage AddPost(PostDTO post)
        {
            try
            {
                var token = ActionContext.Request.Headers.Authorization;
                var data = PostService.AddPostService(post,token.ToString());
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                
                return Request.CreateResponse(HttpStatusCode.Created, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        [Logged]
        [HttpGet]
        [Route("api/post/{PostId}")]
        public HttpResponseMessage GetPost(int PostId)
        {
            try
            {
                var data = PostService.GetPost(PostId);

                if (data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/post/GetAllPosts")]
        public HttpResponseMessage GetAllPosts()
        {
            try
            {
                var allPosts = PostService.GetAllPosts();

                if (allPosts != null && allPosts.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, allPosts);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No posts found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/post/GetSiglePosts")]
        public HttpResponseMessage GetSinglePosts()
        {
            try
            {
                var token = ActionContext.Request.Headers.Authorization;
                var data = PostService.GetSingle(token.ToString());
               

                if (data != null && data.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No posts found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        [Logged]
        [HttpGet]
        [Route("api/post/GetAllUserPosts")]
        public HttpResponseMessage GetAllUserPosts()
        {
            try
            {
                var allPosts = PostService.GetAllUserPosts();

                if (allPosts> 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, allPosts);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "No posts found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }

        
        [HttpPost]
        [Route("api/post/update/{PostId}")]
        public HttpResponseMessage UpdatePost(int PostId, [FromBody] PostDTO post)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }

                var updatedPost = PostService.UpdatePostService(PostId, post);

                if (updatedPost != null)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, updatedPost);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Msg = "Post not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }
        
        [HttpDelete]
        [Route("api/Post/delete/{PostId}")]
        public HttpResponseMessage DeletePost(int PostId)
        {
            try
            {
                var isSuccess = PostService.DeletePostService(PostId);

                if (isSuccess)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Message = "Post deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { Message = "Post not found" });
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { Msg = ex.Message });
            }
        }





    }
}
