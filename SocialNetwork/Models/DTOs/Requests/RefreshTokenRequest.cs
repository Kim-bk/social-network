using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models.DTOs.Requests
{
    public class RefreshTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
