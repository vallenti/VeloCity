using VeloCity.Extensions;
using VeloCity.Models;

namespace VeloCity.Dtos
{
    public class BikeDto
    {
        public BikeDto(Bike bike)
        {
            this.Id = bike.Id;
            this.Status = bike.Status.ToBikeStatusString();
            this.BikeType = bike.BikeTypeId.ToBikeTypeString();
            this.PricePerMinute = bike.BikeType.PricePerMinute;
            this.ParkedAt = bike.ParkedAt?.Name;
        }

        public int Id { get; set; }

        public string Status { get; set; }

        public string BikeType { get; set; }

        public double PricePerMinute { get; set; }

        public string ParkedAt { get; set; }
    }
}
