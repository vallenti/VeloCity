using VeloCity.Models.Enums;

namespace VeloCity.Models
{
    public class Bike
    {
        public int Id { get; set; }

        public BikeStatus Status { get; set; }

        public int BikeTypeId { get; set; }

        public virtual BikeType BikeType { get; set; }

        public int? ParkedAtId { get; set; }

        public virtual Station ParkedAt { get; set; }

        public int? LastParkedAt { get; set; }

        public void Park(int stationCode)
        {
            this.ParkedAtId = stationCode;
            this.Status = BikeStatus.Available;
            this.LastParkedAt = stationCode;
        }

        public void Rent() {
            this.ParkedAtId = null;
            this.Status = BikeStatus.Rented;
        }

        public void Service()
        {
            this.Status = BikeStatus.Service;
            this.LastParkedAt = this.ParkedAtId;
            this.ParkedAtId = null;
        }
    }
}
