using System.Collections.ObjectModel;

namespace VeloCity.Models
{
    public class Station
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime CreatedAt { get; private set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Bike> ParkedBikes { get; set; } = new Collection<Bike>();
    }
}
