using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SocialNetwork.Services.Interfaces;
using SocialNetwork.Models;
using SocialNetwork.Models.DTOs;

namespace SocialNetwork.Services.Mapping
{
    public class Mapper : IMapperCustom
    {
        private readonly IMapper _autoMapper;
        public Mapper(IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }
       
        public List<UserDTO> MapUsers(List<User> users)
        {
            return _autoMapper.Map<List<User>, List<UserDTO>>(users);
        }
    }
}
