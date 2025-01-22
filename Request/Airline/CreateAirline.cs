namespace AirAccess.Request.Airline
{
    public class CreateAirlineRequest
    {
        public required string AirlineName { get; set; }
        public required string AirlineCode { get; set; }
    }
}
