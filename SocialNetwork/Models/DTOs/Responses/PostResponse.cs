using SocialNetwork.Models.DTOs.Responses.Base;
using System.Collections.Generic;

namespace SocialNetwork.Models.DTOs.Responses
{
    public class PostResponse : GeneralResponse
    {
        public List<PostDTO> Posts { get; set; }
    }
}
