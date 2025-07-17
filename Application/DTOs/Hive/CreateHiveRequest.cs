namespace Application.DTOs.Hive
{
    public class CreateHiveRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public Guid UserId { get; set; }
    }
}
