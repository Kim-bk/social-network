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

namespace SocialNetwork.Services
{
    public class PostService : BaseService, IPostService
    {
        #region Cloudinary Informations

        private readonly string CLOUD_NAME = "dor7ghk95";
        private readonly string API_KEY = "588273259994552";
        private readonly string API_SECRET = "YImi-iuUxclgZJFC2-R0cN3tcEA";
        private readonly string CLOUDINARY_API = "https://api.cloudinary.com/v1_1/dor7ghk95/mh/upload";
        private readonly string CLOUDINARY_UPLOAD_PRESET = "ot8kn4em/mh/upload";

        #endregion

        private readonly IPostRepository _postRepo;
        private readonly IUserRepository _userRepo;
        private Cloudinary _cloudinary;
        private readonly List<string> ImageExtensions = new List<string> {".png", ".jpg", ".jpeg" };
        private readonly List<string> VideoExtensions = new List<string> { ".mp4", "m4p", ".m4v",".mpg", ".mpeg", ".m2v", ".mov" };

        public PostService(IPostRepository postRepo, IMapperCustom mapper
            , IUnitOfWork unitOfWork, IUserRepository userRepo) : base(unitOfWork, mapper)
        {
            _postRepo = postRepo;
            _userRepo = userRepo;
        }
        private string UploadImage(string path)
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
                       // UploadPreset = CLOUDINARY_UPLOAD_PRESET,
                        //EagerAsync = true,
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

                Account account = new(CLOUD_NAME, API_KEY, API_SECRET);
                _cloudinary = new Cloudinary(account);
                var fileUrl = UploadImage(post.FileUrl);
                if (fileUrl == "null")
                    return false;

                var newPost = new Post
                {
                    Content = post.Content,
                    FileUrl = fileUrl,
                    IsApproved = false,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    User = user,
                };

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

        public Task<List<Post>> GetFriendPosts(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Post>> GetPosts(int userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> UpdatePost(PostRequest post, int authorId)
        {
            try
            {
                var findPost = await _postRepo.FindAsync(p => p.Id == post.PostId);
                if (findPost == null)
                    return false;

                findPost.Content = post.Content;
                findPost.FileUrl = post.FileUrl;
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
