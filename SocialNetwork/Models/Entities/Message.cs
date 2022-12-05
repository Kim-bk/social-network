using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;
using System.Security.Principal;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Message : BaseEntity
    {
        public Message()
        {
        }
#nullable enable
      
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public virtual User UserSource { get; set; }
        public virtual User UserTarget { get; set; }
    }
}