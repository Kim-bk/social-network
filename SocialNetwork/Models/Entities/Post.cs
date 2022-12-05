using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;
using System.Security.Principal;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
        }
#nullable enable
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int AuthorId { get; set; }
        public virtual User User { get; set; }
    }
}