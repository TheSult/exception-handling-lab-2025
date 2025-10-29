using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Part1
{
    internal class Program
    {
        private const string LogName = "Application";
        private const string SourceName = "Lab5_ExceptionApp";

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 5 Part 1\n");

            try
            {
                // Ask user for input
                Console.Write("Enter first number: ");
                int number1 = int.Parse(Console.ReadLine());
                Console.Write("Enter second number: ");
                int number2 = int.Parse(Console.ReadLine());


                int result = number1 / number2;
                Console.WriteLine($"\nResult = {result}");

                // Log success
                LogEvent("Division completed successfully.", EventLogEntryType.Information);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("\nError: You cannot divide by zero!");
                LogEvent($"DivideByZeroException: {ex.Message}", EventLogEntryType.Error);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("\nError: Please enter a valid number!");
                LogEvent($"FormatException: {ex.Message}", EventLogEntryType.Warning);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nAn unexpected error occurred.");
                LogEvent($"General Exception: {ex.Message}", EventLogEntryType.Error);
            }
            finally
            {
                LogEvent("Division attempt completed.", EventLogEntryType.Information);
                Console.WriteLine("Operation completed. Check Event Viewer for logs.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void LogEvent(string message, EventLogEntryType type)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(message, type, 101, 1);
            }
        }
    }
}
