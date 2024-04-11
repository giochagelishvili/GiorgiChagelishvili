using Forum.Domain.BaseEntities;
using Forum.Domain.Topics;
using Microsoft.AspNetCore.Identity;

namespace Forum.Domain.Users
{
    public class User : IdentityUser<int>, IEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Status Status { get; set; }

        // Navigation properties
        public List<Topic>? Topics { get; set; }
    }
}
