using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Models.DTOs.Requests
{
    public class CredentialRequest
    {
        [Required]
        public int RoleId { get; set; }
        [Required]
        public int UserGroupId { get; set; }
    }
}
