using AutoMapper;
using SocialNetwork.Models;
using SocialNetwork.Models.DTOs;

namespace SocialNetwork.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User -> UserDTO
            CreateMap<User, UserDTO>();
        }
    }
}

