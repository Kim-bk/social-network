using SocialNetwork.Models.Base;
using System.Collections.Generic;
using System;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class Interaction : BaseEntity
    {
        public Interaction()
        {
        }
#nullable enable

        public string Type { get; set; }
    }
}