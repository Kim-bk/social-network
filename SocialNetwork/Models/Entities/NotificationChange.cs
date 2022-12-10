using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class NotificationChange : BaseEntity
    {
        public NotificationChange()
        {
        }
#nullable enable

        public int NotificationObjectId { get; set; }
        public int ActorId { get; set; }
        public bool Status { get; set; }
    }
}