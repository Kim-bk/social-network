using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Comment : BaseEntity
    {
        public Comment()
        {

        }
#nullable enable
       
        public string Content { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PostId { get; set; }
        public int AuthorId { get; set; }
    }
}