using VeloCity.Extensions;
using VeloCity.Models;

namespace VeloCity.Dtos
{
    public class StationDto
    {
        public StationDto(Station station)
        {
            this.Id = station.Id;
            this.Name = station.Name;
            this.Capacity = station.Capacity;
            this.Latitude = station.Latitude;
            this.Longitude = station.Longitude;
            this.UpdatedAt = DateTime.Now.ToDateString();
            this.ParkedBikesCount = station.ParkedBikes.Count;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string UpdatedAt { get; set; }

        public int ParkedBikesCount { get; set; }

        public int AvailableBikes => Capacity - ParkedBikesCount;
    }
}
