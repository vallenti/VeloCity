using System.Collections.ObjectModel;
using VeloCity.RequestModels;

namespace VeloCity.Models
{
    public class Station
    {
        public Station(StationCreateRequest request)
        {
            this.Update(request);
        }

        public  Station() { }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Bike> ParkedBikes { get; set; } = new Collection<Bike>();

        public void Update(StationCreateRequest request)
        {
            this.Name = request.StationName;
            this.Capacity = request.StationBikesCount;
            var coordinates = request.stationCoordinates.Split(',').ToArray();
            this.Latitude = double.Parse(coordinates[0]);
            this.Longitude = double.Parse(coordinates[1]);
        }
    }
}
