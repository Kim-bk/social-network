using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
        }
#nullable enable
        public string? Content { get; set; }
        public string? FileUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool? IsApproved { get; set; }
        public virtual User User { get; set; }
    }
}