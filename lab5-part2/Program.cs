using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5_part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lab 5 Part 1\n");

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            try
            {
                CheckPassword(password);
                Console.WriteLine("Password accepted!");
            }
            catch (PasswordComplexityException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Method that checks password length
        static void CheckPassword(string password)
        {
            if (password.Length < 8)
            {
                throw new PasswordComplexityException();
            }
        }
    }
}
