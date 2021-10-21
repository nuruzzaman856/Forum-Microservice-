using Common.Services.Entities;
using System;

namespace Forum.Domain.Entities
{
    public class ApplicationUser : AuditableEntity
    {
        public Guid Id { get; set; }

    }
}
