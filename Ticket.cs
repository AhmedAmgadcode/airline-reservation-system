namespace AirlineReservationProject
{
    /// <summary>A booked ticket. Sealed because it should never be subclassed.</summary>
    sealed class Ticket
    {
        public int TicketNumber { get; set; }
        public string PassengerName { get; set; }
        public string FlightNumber { get; set; }

        public Ticket(int ticketNumber,
                      string passengerName,
                      string flightNumber)
        {
            TicketNumber = ticketNumber;
            PassengerName = passengerName;
            FlightNumber = flightNumber;
        }

        public override string ToString() => $"Ticket #{TicketNumber} | Passenger: {PassengerName} | Flight: {FlightNumber}";
    }
}
