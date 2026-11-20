namespace AirlineReservationProject
{
    /// <summary>Abstract base class for anyone who uses the system.</summary>
    abstract class Client
    {
        public string Name { get; set; }

        protected Client(string name)
        {
            Name = name;
        }

        public abstract void DisplayInfo();
    }
}
