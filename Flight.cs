using System;

namespace AirlineReservationProject
{
    class Flight
    {
        public string FlightNumber { get; set; }
        public string From { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }

        public Flight(string flightNumber,
                      string from,
                      string destination,
                      DateTime departureTime,
                      int totalSeats)
        {
            FlightNumber = flightNumber;
            From = from;
            Destination = destination;
            DepartureTime = departureTime;
            TotalSeats = totalSeats;
            BookedSeats = 0;
        }

        public int AvailableSeats() => TotalSeats - BookedSeats;

        public override string ToString()
        {
            return $"Flight: {FlightNumber} | From: {From} | To: {Destination} | Departure: {DepartureTime:yyyy-MM-dd HH:mm} | Available Seats: {AvailableSeats()}";
        }
    }
}
