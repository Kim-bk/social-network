using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class NotificationObject : BaseEntity
    {
        public NotificationObject()
        {
        }
#nullable enable

        public int EntityTypeId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}