using System;

namespace AirlineReservationProject
{
    class Passenger : Client
    {
        public Passenger(string name) : base(name) { }

        public override void DisplayInfo() => Console.WriteLine($"Passenger Name: {Name}");
    }
}
