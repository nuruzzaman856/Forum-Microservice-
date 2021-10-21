using System;

namespace Common.Services.Entities
{
    public class AuditableEntity
    {
        public string CreateBy { get; set; }
        public DateTime CreateAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
