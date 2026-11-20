using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirlineReservationProject
{
    class AirlineReservationSystem : IReport
    {
        private readonly List<Flight> flights = new List<Flight>();
        private readonly List<Reservation> reservations = new List<Reservation>();

        // Static member shared by the whole system.
        public static int TotalReservations = 0;
        private int reservationCounter = 1;
        private int ticketCounter = 1000;

        /// <summary>Adds sample flights. Dates are relative to today so they are always upcoming.</summary>
        public void SeedFlights()
        {
            DateTime today = DateTime.Today;

            flights.Add(new Flight("MS1", "Cairo", "Dubai", today.AddDays(7).AddHours(8).AddMinutes(30), 100));
            flights.Add(new Flight("MS2", "Cairo", "London", today.AddDays(8).AddHours(10), 80));
            flights.Add(new Flight("MS3", "Alexandria", "Paris", today.AddDays(9).AddHours(14).AddMinutes(15), 120));
            flights.Add(new Flight("MS4", "Cairo", "New York", today.AddDays(30).AddHours(21).AddMinutes(15), 50));
        }

        public void ShowFlights()
        {
            Console.WriteLine("\n========== AVAILABLE FLIGHTS ==========");
            foreach (Flight flight in flights)
                Console.WriteLine(flight);
        }

        public void BookFlight()
        {
            try
            {
                string passengerName = ValidationHelper.ReadString("Enter Passenger Name: ");
                string flightNumber = ValidationHelper.ReadString("Enter Flight Number: ");

                Flight? selectedFlight = flights.FirstOrDefault(f =>
                    f.FlightNumber.Equals(flightNumber, StringComparison.OrdinalIgnoreCase));

                if (selectedFlight == null)
                {
                    Console.WriteLine("Flight not found.");
                    return;
                }

                if (selectedFlight.DepartureTime < DateTime.Now)
                {
                    Console.WriteLine("This flight has already departed.");
                    return;
                }

                if (selectedFlight.AvailableSeats() <= 0)
                {
                    Console.WriteLine("No available seats.");
                    return;
                }

                selectedFlight.BookedSeats++;

                Passenger passenger = new Passenger(passengerName);
                Ticket ticket = new Ticket(ticketCounter++, passengerName, selectedFlight.FlightNumber);
                Reservation reservation = new Reservation(reservationCounter++, passenger, selectedFlight, ticket);

                reservations.Add(reservation);
                TotalReservations++;

                Console.WriteLine("\nReservation completed successfully.");
                Console.WriteLine($"Reservation ID: {reservation.ReservationId}");
                Console.WriteLine(ticket);
            }
            catch (EndOfStreamException)
            {
                throw; // let Program.Main end the session cleanly
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void ShowReservations()
        {
            Console.WriteLine("\n========== RESERVATIONS ==========");
            if (reservations.Count == 0)
            {
                Console.WriteLine("No reservations found.");
                return;
            }
            foreach (Reservation reservation in reservations)
                Console.WriteLine(reservation);
        }

        public void CancelReservation()
        {
            try
            {
                int reservationId = ValidationHelper.ReadInt("Enter Reservation ID to cancel: ");
                Reservation? reservation = reservations.FirstOrDefault(r => r.ReservationId == reservationId);

                if (reservation == null)
                {
                    Console.WriteLine("Reservation not found.");
                    return;
                }

                reservation.FlightDetails.BookedSeats--;
                reservations.Remove(reservation);
                TotalReservations--;

                Console.WriteLine("Reservation cancelled successfully.");
            }
            catch (EndOfStreamException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void GeneralReport()
        {
            Console.WriteLine("\n========== FLIGHT SUMMARY REPORT ==========");
            foreach (Flight flight in flights)
            {
                Console.WriteLine($"Flight Number : {flight.FlightNumber}");
                Console.WriteLine($"Destination   : {flight.Destination}");
                Console.WriteLine($"Total Seats   : {flight.TotalSeats}");
                Console.WriteLine($"Booked Seats  : {flight.BookedSeats}");
                Console.WriteLine($"Available     : {flight.AvailableSeats()}");
                Console.WriteLine("-------------------------------------------");
            }
            Console.WriteLine($"Total Reservations: {TotalReservations}");
        }
    }
}
