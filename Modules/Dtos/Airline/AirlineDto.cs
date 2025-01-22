namespace AirAccess.Modules.Dtos.Airline
{
    public class AirlineDto
    {
        public Guid Id { get; set; }
        public required string AirlineName { get; set; }
        public required string AirlineCode { get; set; }
    }
}

