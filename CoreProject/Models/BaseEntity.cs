using System;

namespace CoreProject.Models
{
    public class BaseEntity
    {
        public Entity()
        {

        }
        public long Id { get; protected set; }
        public DateTimeOffset CreatedDate { get; protected set; } = DateTimeOffset.UtcNow;
    }
}
