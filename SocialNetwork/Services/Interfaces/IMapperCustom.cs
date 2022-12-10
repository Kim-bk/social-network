using System.Collections.Generic;
using SocialNetwork.Models;
using SocialNetwork.Models.DTOs;

namespace SocialNetwork.Services.Interfaces
{
    public interface IMapperCustom
    {
        List<UserDTO> MapUsers(List<User> users);
    }
}

