namespace VeloCity.Models
{
    public class BikeType
    {
        public const int Classic = 1;
        public const int Road = 2;
        public const int Mountain = 3;
        public const int Electric = 4;

        public int Id { get; set; }

        public string Name { get; set; }

        public double PricePerMinute { get; set; }
    }
}
