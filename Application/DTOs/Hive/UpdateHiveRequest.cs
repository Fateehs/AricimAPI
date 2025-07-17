namespace Application.DTOs.Hive
{
    public class UpdateHiveRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
    }
}
