using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Notification : BaseEntity
    {
        public Notification()
        {
        }
#nullable enable
      
        public bool Status { get; set; }
        public int NotificationObjectId { get; set; }
        public int PostId { get; set; }
        public int NotifierId { get; set; }
        public virtual NotificationObject NotificationObject { get; set; }
    }
}