using System;

namespace SocialNetwork.Models.DTOs
{
    public class PostDTO
    {
        public string Content { get; set; }
        public string FileUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
