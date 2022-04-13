using System.ComponentModel.DataAnnotations.Schema;
using VeloCity.Models.Enums;

namespace VeloCity.Models
{
    public class Trip
    {
        public Trip(ApplicationUser user, Bike bike)
        {
            this.User = user;
            this.Bike = bike;
        }

        public int Id { get; private set; }

        public DateTime Start { get; private set; }

        public DateTime? End { get; private set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; private set; }

        public int BikeId { get; private set; }

        public virtual Bike Bike { get; private set; }

        [NotMapped]
        public double TotalAmount => this.TotalMinutes * this.Bike.BikeType.PricePerMinute;

        [NotMapped]
        public int TotalMinutes => (End.Value - Start).Minutes;

        public void Begin()
        {
            this.Start = DateTime.Now;
            this.Bike.Status = BikeStatus.Rented;
        }

        public void Finish()
        {
            this.End = DateTime.Now;
            this.Bike.Status = BikeStatus.Available;
        }

    }
}
