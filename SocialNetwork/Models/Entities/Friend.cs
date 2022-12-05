using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;
using System.Security.Principal;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Friend : BaseEntity
    {
        public Friend()
        {
        }
#nullable enable
        public DateTime CreatedDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime DeniedDate { get; set; }
        public bool Status { get; set; }
        public int SourceId { get; set; }
        public int TargetId { get; set; }
        public virtual User UserSource { get; set; }
        public virtual User UserTarget { get; set; }
    }
}