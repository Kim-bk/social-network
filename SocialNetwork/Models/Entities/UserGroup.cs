using SocialNetwork.Models.Base;
using System.Collections.Generic;

#nullable disable

namespace SocialNetwork.Models
{
    public partial class UserGroup : BaseEntity
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted {get; set;}
        public virtual ICollection<User> Users { get; set; }
    }
}
