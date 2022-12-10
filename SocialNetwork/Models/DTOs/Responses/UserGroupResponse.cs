using SocialNetwork.Models.DTOs.Responses.Base;
using System.Collections.Generic;

namespace SocialNetwork.Models.DTOs.Responses
{
    public class UserGroupResponse : GeneralResponse
    {
        public List<UserGroup> UserGroups { get; set; }
    }
}
