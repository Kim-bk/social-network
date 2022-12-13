using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
using SocialNetwork.Models.DTOs;
using SocialNetwork.Models.DTOs.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Interfaces
{
    public interface IPostService
    {
        public Task<bool> AddPost(PostRequest post, int authorId);
        public Task<bool> DeletePost(int postId);
        public Task<bool> UpdatePost(PostRequest post, int authorId);
        public Task<List<PostDTO>> GetPosts(int userId);
        public Task<List<PostDTO>> GetFriendPosts(int userId);
    }
}
