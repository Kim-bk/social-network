using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
