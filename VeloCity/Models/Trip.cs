using System.ComponentModel.DataAnnotations.Schema;
using VeloCity.Models.Enums;

namespace VeloCity.Models
{
    public class Trip
    {
        public Trip(string userId, Bike bike)
        {
            this.UserId = userId;
            this.BikeId = bike.Id;
            this.Bike = bike;
        }

        private Trip() { } //Used by EF

        public int Id { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime? End { get; private set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; private set; }

        public int BikeId { get; private set; }

        public virtual Bike Bike { get; private set; }

        [NotMapped]
        public bool IsFinished => this.End.HasValue;

        public void Begin()
        {
            this.Start = DateTime.Now;
            this.Bike.Rent();
        }

        public void Finish(int stationId)
        {
            this.End = DateTime.Now;
            this.Bike.Park(stationId);
        }

    }
}
