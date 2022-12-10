using SocialNetwork.Models.DTOs.Responses.Base;

namespace SocialNetwork.Models.DTOs.Responses
{
    public class RefreshTokenResponse : GeneralResponse
    {
        public RefreshToken RefreshToken { get; set; }
    }
}
