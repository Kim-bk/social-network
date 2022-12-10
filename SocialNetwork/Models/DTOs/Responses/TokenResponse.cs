using SocialNetwork.Models.DTOs.Responses.Base;

namespace SocialNetwork.Models.DTOs.Responses
{
    public class TokenResponse : GeneralResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ShopId { get; set; }
    }
}
