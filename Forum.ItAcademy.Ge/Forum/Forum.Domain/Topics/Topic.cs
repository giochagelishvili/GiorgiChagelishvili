﻿using Forum.Domain.BaseEntities;
using Forum.Domain.Comments;
using Forum.Domain.Users;

namespace Forum.Domain.Topics
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int AuthorId { get; set; } = default!;
        public State State { get; set; }

        // Navigation property
        public List<Comment>? Comments { get; set; }
        public User Author { get; set; } = default!;
    }
}
