using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class User : BaseEntity
    {
        public User()
        {
        }
#nullable enable

        public int? ShopId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UserGroupId { get; set; }
        public bool IsActivated { get; set; }
        public System.Guid ActivationCode { get; set; }
        public System.Guid ResetPasswordCode { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }
}