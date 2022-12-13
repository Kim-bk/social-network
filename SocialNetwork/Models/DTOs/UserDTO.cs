using System;

namespace SocialNetwork.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsFriend { get; set; }
    }
}
