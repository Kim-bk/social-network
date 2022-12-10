using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}