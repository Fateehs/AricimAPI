using System;

namespace Domain.Entities
{
    public class Hive
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Active";
        public double? HoneyAmount { get; set; } = 0;

        // İlişki - Her kovanın bir sahibi vardır
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
