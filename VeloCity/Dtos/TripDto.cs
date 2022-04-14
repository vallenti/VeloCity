using VeloCity.Extensions;
using VeloCity.Models;

namespace VeloCity.Dtos
{
    public class TripDto
    {
        public TripDto(Trip trip)
        {
            this.Id = trip.Id;
            this.StartDate = trip.Start;
            this.EndDate = trip.End;
            this.Start = trip.Start.ToDateString();
            this.End = trip.End.HasValue ? trip.End.Value.ToDateString() : string.Empty;
            this.User = trip.User.UserName;
            this.Bike = new BikeDto(trip.Bike);
            this.BikeId = trip.BikeId;
        }

        public int Id { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public string Start { get; private set; }
        
        public string End { get; private set; }

        public string User { get; private set; }

        public int BikeId { get; private set; }

        public virtual BikeDto Bike { get; private set; }

        public double TotalAmount => this.TotalMinutes.HasValue ? 
            this.TotalMinutes.Value * this.Bike.PricePerMinute :
            (DateTime.Now - StartDate).Minutes * this.Bike.PricePerMinute;

        public int? TotalMinutes => EndDate.HasValue ? 
            (EndDate.Value - StartDate).Minutes : 
            (DateTime.Now - StartDate).Minutes;

    }
}
