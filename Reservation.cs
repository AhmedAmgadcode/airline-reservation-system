namespace AirlineReservationProject
{
    class Reservation
    {
        public int ReservationId { get; set; }
        public Passenger Passenger { get; set; }
        public Flight FlightDetails { get; set; }
        public Ticket TicketDetails { get; set; }

        public Reservation(int reservationId,
                           Passenger passenger,
                           Flight flight,
                           Ticket ticket)
        {
            ReservationId = reservationId;
            Passenger = passenger;
            FlightDetails = flight;
            TicketDetails = ticket;
        }

        public override string ToString() =>
            $"Reservation ID: {ReservationId} | Passenger: {Passenger.Name} | Flight: {FlightDetails.FlightNumber} | Departure: {FlightDetails.DepartureTime:yyyy-MM-dd HH:mm}";
    }
}
