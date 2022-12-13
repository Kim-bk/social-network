using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
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
        public Task<List<Post>> GetPosts(int userId);
        public Task<List<Post>> GetFriendPosts(int userId);
    }
}
