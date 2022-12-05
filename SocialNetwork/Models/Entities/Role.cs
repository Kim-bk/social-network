using SocialNetwork.Models.Base;
using System;
using System.Collections.Generic;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Role : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set;}
    }
}
