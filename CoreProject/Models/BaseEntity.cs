using System;

namespace CoreProject.Models
{
    public class BaseEntity
    {
        public long Id { get; protected set; }
        public DateTimeOffset CreatedDate { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
