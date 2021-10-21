using Common.Services.Entities;
using System;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class ForumEntity : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }

    }
}
