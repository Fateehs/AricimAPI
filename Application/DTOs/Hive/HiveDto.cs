namespace Application.DTOs.Hive
{
    public class HiveDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; } = "Created";
        public Guid UserId { get; set; }
    }
}
