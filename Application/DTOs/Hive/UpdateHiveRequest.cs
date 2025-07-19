namespace Application.DTOs.Hive
{
    public class UpdateHiveRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";

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
