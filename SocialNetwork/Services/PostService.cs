using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using SocialNetwork.Models;
using SocialNetwork.Models.DAL;
using SocialNetwork.Models.DAL.Interfaces;
using SocialNetwork.Models.DTOs.Requests;
using SocialNetwork.Services.Base;
using SocialNetwork.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using SocialNetwork.Models.DAL.Repositories;
using System.IO;
using SocialNetwork.Models.DTOs;

namespace SocialNetwork.Services
{
    public class PostService : BaseService, IPostService
    {
        #region Image vs Video extensions
        private readonly List<string> ImageExtensions = new() { ".png", ".jpg", ".jpeg" };
        private readonly List<string> VideoExtensions = new() { ".mp4", "m4p", ".m4v", ".mpg", ".mpeg", ".m2v", ".mov" };
        #endregion

        #region Cloudinary Informations

        private readonly string CLOUD_NAME = "dor7ghk95";
        private readonly string API_KEY = "588273259994552";
        private readonly string API_SECRET = "YImi-iuUxclgZJFC2-R0cN3tcEA";

        #endregion

        private readonly IPostRepository _postRepo;
        private readonly IFriendRepository _friendRepo;
        private readonly IUserRepository _userRepo;
        private Cloudinary _cloudinary;

        public PostService(IPostRepository postRepo, IMapperCustom mapper
            , IUnitOfWork unitOfWork, IUserRepository userRepo
            , IFriendRepository friendRepo) : base(unitOfWork, mapper)
        {
            _postRepo = postRepo;
            _userRepo = userRepo;
            _friendRepo = friendRepo;
        }
        private string UploadFile(string path)
        {
            try
            {
                string extension = Path.GetExtension(path).ToLower();
                if (ImageExtensions.Contains(extension))
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(path),
                        EagerAsync = true,
                    };

                    var uploadResult = _cloudinary.Upload(uploadParams);
                    return uploadResult.Url.ToString();
                }    

                else if (VideoExtensions.Contains(extension))
                {
                    var uploadParams = new VideoUploadParams
                    {
                        File = new FileDescription(path),
                    };

                    var uploadResult = _cloudinary.UploadLarge(uploadParams);
                    return uploadResult.Url.ToString();
                }

                else
                {
                    return "null";
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> AddPost(PostRequest post, int authorId)
        {
            try
            {
                var user = await _userRepo.FindAsync(us => us.Id == authorId);

                var newPost = new Post
                {
                    Content = post.Content,
                    IsApproved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    User = user,
                };

                if (post.FileUrl != "")
                {
                    Account account = new(CLOUD_NAME, API_KEY, API_SECRET);
                    _cloudinary = new Cloudinary(account);
                    var fileUrl = UploadFile(post.FileUrl);

                    if (fileUrl == "null")
                        return false;

                    newPost.FileUrl = fileUrl;
                }

                await _postRepo.AddAsync(newPost);
                await _unitOfWork.CommitTransaction();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeletePost(int postId)
        {
            try
            {
                var findPost = await _postRepo.FindAsync(p => p.Id == postId);
                if (findPost == null)
                    return false;

                _postRepo.Delete(findPost);
                await _unitOfWork.CommitTransaction();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PostDTO>> GetFriendPosts(int userId)
        {
            var friendIds = await _friendRepo.GetFriendsOfUser(userId);
            var userFriendPosts = await _postRepo.GetUserFriendPosts(friendIds);
            return _mapper.MapPosts(userFriendPosts);
        }

        public async Task<List<PostDTO>> GetPosts(int userId)
        {
            var userPosts = await _postRepo.GetUserPosts(userId);
            return _mapper.MapPosts(userPosts);
        }

        public async Task<bool> UpdatePost(PostRequest post, int authorId)
        {
            try
            {
                var findPost = await _postRepo.FindAsync(p => p.Id == post.PostId);
                if (findPost == null)
                    return false;

                if (post.FileUrl != "")
                {
                    Account account = new(CLOUD_NAME, API_KEY, API_SECRET);
                    _cloudinary = new Cloudinary(account);
                    var fileUrl = UploadFile(post.FileUrl);
                    findPost.FileUrl = fileUrl;
                }    
              
                findPost.Content = post.Content;
                findPost.UpdatedDate = DateTime.Now;

                //_postRepo.Update(findPost);
                await _unitOfWork.CommitTransaction();
                return true;
            }

            catch
            {
                throw;
            }
        }
    }
}
