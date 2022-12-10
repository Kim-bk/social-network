using SocialNetwork.Models.DTOs.Responses.Base;
using System.Collections.Generic;

namespace SocialNetwork.Models.DTOs.Responses
{
    public class CredentialResponse
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActivated { get; set; }
    }
}
