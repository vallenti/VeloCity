using System.ComponentModel.DataAnnotations.Schema;

namespace VeloCity.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int BikeId { get; set; }

        public virtual Bike Bike { get; set; }

        [NotMapped]
        public double TotalAmount => this.TotalMinutes * this.Bike.BikeType.PricePerMinute;

        [NotMapped]
        public int TotalMinutes => (End.Value - Start).Minutes;

    }
}
