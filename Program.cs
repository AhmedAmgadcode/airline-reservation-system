using System;
using System.IO;

namespace AirlineReservationProject
{
    class Program
    {
        static void Main(string[] args)
        {
            AirlineReservationSystem system = new AirlineReservationSystem();
            system.SeedFlights();

            try
            {
                int choice;
                do
                {
                    Console.WriteLine("\n====================================");
                    Console.WriteLine(" AIRLINE RESERVATION SYSTEM ");
                    Console.WriteLine("====================================");
                    Console.WriteLine("1. Show Flights");
                    Console.WriteLine("2. Book Flight");
                    Console.WriteLine("3. Show Reservations");
                    Console.WriteLine("4. Cancel Reservation");
                    Console.WriteLine("5. Flight Summary Report");
                    Console.WriteLine("6. Exit");

                    choice = ValidationHelper.ReadInt("Enter your choice: ");

                    switch (choice)
                    {
                        case 1:
                            system.ShowFlights();
                            break;
                        case 2:
                            system.BookFlight();
                            break;
                        case 3:
                            system.ShowReservations();
                            break;
                        case 4:
                            system.CancelReservation();
                            break;
                        case 5:
                            system.GeneralReport();
                            break;
                        case 6:
                            Console.WriteLine("Exiting program...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                } while (choice != 6);
            }
            catch (EndOfStreamException)
            {
                Console.WriteLine("\nInput closed. Exiting program...");
            }
        }
    }
}
