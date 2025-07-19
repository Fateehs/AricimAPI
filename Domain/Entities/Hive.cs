using System;

namespace Domain.Entities
{
    public class Hive
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

        public DateTime? LastInspection { get; set; }
        public DateTime? NextInspection { get; set; }
        public DateTime? QueenBirthDate { get; set; }
        public string? QueenStatus { get; set; }
        public string? Breed { get; set; }
        public bool? IsMarked { get; set; }
        public DateTime? RequeeningDate { get; set; }
        public string? CombCondition { get; set; }
        public int? FrameCount { get; set; }
        public float? HoneyAmount { get; set; }
        public float? HarvestedHoney { get; set; }
        public string? FeedingStatus { get; set; }
        public string? DiseaseSymptoms { get; set; }
        public string? BeeBehavior { get; set; }
        public string? Pests { get; set; }
        public string? Notes { get; set; }
    }

}
