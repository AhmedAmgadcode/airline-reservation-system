using System;
using System.IO;

namespace AirlineReservationProject
{
    /// <summary>Static helpers for reading validated console input.</summary>
    static class ValidationHelper
    {
        /// <summary>Reads a line, or throws if the input stream has ended.</summary>
        private static string ReadLineOrThrow()
        {
            string? line = Console.ReadLine();
            if (line == null)
                throw new EndOfStreamException("Input stream closed.");
            return line;
        }

        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(ReadLineOrThrow(), out int number))
                    return number;
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        public static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = ReadLineOrThrow().Trim();
                if (input.Length > 0)
                    return input;
                Console.WriteLine("Input cannot be empty.");
            }
        }
    }
}
