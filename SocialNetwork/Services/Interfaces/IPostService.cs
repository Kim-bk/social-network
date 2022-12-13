using Microsoft.AspNetCore.Http;
using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Models.DTOs.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IPostService
    {
        public Task<bool> AddPost(PostRequest post, int authorId);
        public Task<bool> DeletePost(int postId);
        public Task<PostResponse> UpdatePost(PostRequest post, int potsId);
        public Task<List<PostDTO>> GetPosts(int userId);
        public Task<List<PostDTO>> GetFriendPosts(int userId);
    }
}
