using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace OOPS
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select a task to run (1-3) or enter 0 to exit:");
                Console.WriteLine("1. OOPS Concept");
                Console.WriteLine("2. OOPS Implementation");
                Console.WriteLine("3. Ball game");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        OOPSConcept.OOPS();
                        break;
                    case 2:
                        OOP_Implementation.Implementation();
                        break;
                    case 3:
                        BallGame.Game();
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
