namespace VeloCity.RequestModels
{
    public class StationCreateRequest
    {
        public string StationName { get; set; }
        public int StationBikesCount { get; set; }
        public string stationCoordinates { get; set; }
    }
}
