using SocialNetwork.Models.Base;

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
