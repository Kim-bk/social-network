using SocialNetwork.Models.DTOs.Responses.Base;

namespace SocialNetwork.Models.DTOs.Responses
{
    public class UserResponse : GeneralResponse
    {
        public User User { get; set; }
        public UserDTO UserDTO { get; set; }
    }
}
