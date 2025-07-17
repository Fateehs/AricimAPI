namespace Application.DTOs.Hive
{
    public class HiveSummaryDto
    {
        public int TotalHives { get; set; }
        public int ActiveHives { get; set; }
        public int PassiveHives { get; set; }
        public double TotalHoney { get; set; }
    }
}
