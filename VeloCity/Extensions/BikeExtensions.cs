using VeloCity.Models;
using VeloCity.Models.Enums;

namespace VeloCity.Extensions
{
    public static class BikeExtensions
    {
        public static string ToBikeTypeString(this int bikeTypeId)
            => bikeTypeId switch
            {
                BikeType.Classic => "Класическо",
                BikeType.Road => "Шосейно",
                BikeType.Mountain => "Планинско",
                BikeType.Electric => "Електрическо",
                _ => throw new NotImplementedException($"{bikeTypeId} is not recognised type")
            };

        public static string ToBikeStatusString(this BikeStatus status)
            => status switch
            {
                BikeStatus.Available => "Налично",
                BikeStatus.Rented => "Наето",
                BikeStatus.Service => "Техническо обслуване",
                _ => throw new NotImplementedException($"{status} is not recognised status")
            };
    }
}
