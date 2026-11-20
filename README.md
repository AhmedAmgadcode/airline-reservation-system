# Airline Reservation System (C#)

A console application in C# for browsing flights and managing passenger reservations. It was written as a university team project (team of three, February to May 2026) to practice object-oriented programming in C#.

## Features

- List available flights with departure time and remaining seats.
- Book a flight for a passenger. The system checks that the flight exists, has not departed and still has free seats, then issues a ticket and a reservation ID.
- Show all reservations.
- Cancel a reservation by ID, which frees the seat again.
- Print a flight summary report (total, booked and available seats per flight, plus the total number of reservations).
- Input validation for every prompt, with a clean exit if the input stream closes.

Sample flights are generated relative to today's date, so they are always in the future.

## Run it

Requires the [.NET SDK](https://dotnet.microsoft.com/download) (version 8 or newer).

```bash
dotnet run
```

The project targets `net8.0` and is set to roll forward to newer runtimes. If you only have a newer SDK, you can change `TargetFramework` in `AirlineReservationSystem.csproj`.

## Example session

```
====================================
 AIRLINE RESERVATION SYSTEM
====================================
1. Show Flights
2. Book Flight
3. Show Reservations
4. Cancel Reservation
5. Flight Summary Report
6. Exit
Enter your choice: 2
Enter Passenger Name: Ahmed
Enter Flight Number: MS1

Reservation completed successfully.
Reservation ID: 1
Ticket #1000 | Passenger: Ahmed | Flight: MS1
```

## OOP concepts used

| Concept | Where |
|---|---|
| Abstraction (abstract class and method) | `Client` and `DisplayInfo()` |
| Inheritance and polymorphism | `Passenger : Client` overrides `DisplayInfo()` |
| Interface | `IReport`, implemented by `AirlineReservationSystem` |
| Sealed class | `Ticket` |
| Static class | `ValidationHelper` |
| Static member | `AirlineReservationSystem.TotalReservations` |
| Encapsulation | Properties on `Flight`, `Ticket`, `Reservation` |
| Method overriding | `ToString()` on `Flight`, `Ticket` and `Reservation` |
| Collections and LINQ | `List<T>`, `FirstOrDefault` |
| Exception handling | Booking and cancellation, end-of-input handling |

## Project structure

```
AirlineReservationSystem.csproj
src/
  Program.cs                    Menu loop
  AirlineReservationSystem.cs   Booking, cancellation and reporting logic
  Client.cs / Passenger.cs      Abstract base class and passenger
  Flight.cs / Ticket.cs / Reservation.cs
  IReport.cs                    Report interface
  ValidationHelper.cs           Validated console input
```

## Known limitations

- Data is kept in memory only, so reservations are lost when the program exits.
- Flights are seeded sample data, with no way to add or edit flights from the menu.
- There is no seat selection, pricing or payment.
- There are no automated tests.

## License

MIT, see `LICENSE`.
