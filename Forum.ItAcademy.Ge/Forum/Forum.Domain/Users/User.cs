using Forum.Domain.BaseEntities;
using Microsoft.AspNetCore.Identity;

namespace Forum.Domain.Users
{
    public class User : IdentityUser, IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Status Status { get; set; }
    }
}
