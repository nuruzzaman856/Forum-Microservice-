using Common.Services.Entities;
using System;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class Post : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }

        public Guid ForumId { get; set; }
        public virtual ForumEntity Forum { get; set; }

        public virtual IEnumerable<PostReply> Replies { get; set; }


    }
}
