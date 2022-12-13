using Microsoft.AspNetCore.Http;
using System;

namespace SocialNetwork.Models.DTOs.Requests
{
    public class PostRequest
    {
        public IFormFile File { get; set; }
        public string Content { get; set; }
    }
}
