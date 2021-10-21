using Common.Services.Entities;
using System;

namespace Forum.Domain.Entities
{
    public class PostReply : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Post Post { get; set; }

    }
}
