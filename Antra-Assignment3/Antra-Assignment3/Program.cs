using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Antra_Assignment3
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select a task to run (1-2) or enter 0 to exit:");
                Console.WriteLine("1. FibonacciSequence");
                Console.WriteLine("2. ReverseArray");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        FibonacciSequence.Sequence();
                        break;
                    case 2:
                        ReverseAnArray.ReverseArray(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
