using System;

namespace SocialNetwork.Models.DTOs.Requests
{
    public class PostRequest
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public string FileUrl { get; set; }

    }
}
