using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;
using System.Security.Principal;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class PostInteractions : BaseEntity
    {
        public PostInteractions()
        {
        }
#nullable enable
        public int PostId { get; set; }
        public int InteractionId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        public virtual Interaction Interaction { get; set; }
    }
}