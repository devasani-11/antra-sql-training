using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Antra_C__Learning
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Select a task to run (1-9) or enter 0 to exit:");
                Console.WriteLine("1. Understanding Types");
                Console.WriteLine("2. Centuries Converter");
                Console.WriteLine("3. Fizbuzz counting game");
                Console.WriteLine("4. Fizbuzz Guessing Game");
                Console.WriteLine("5. Print a Pyramid");
                Console.WriteLine("6. Generate random number");
                Console.WriteLine("7. Calculate age in days");
                Console.WriteLine("8. Greet with time");
                Console.WriteLine("9. Increment numbers");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        UnderstandingTypes.DisplayInfo();
                        break;
                    case 2:
                        CenturiesConverter.Converter();
                        break;
                    case 3:
                        FizBuzz.CountingGame();
                        break;
                    case 4:
                        FizBuzz.GuessinGame();
                        break;
                    case 5:
                        Pyramid.PrintPyramid();
                        break;
                    case 6:
                        GuessTheNumber.GuessNumber();
                        break;
                    case 7:
                        AgeInDays.CalculateAge();
                        break;
                    case 8:
                        Greeting.GreetOnTime();
                        break;
                    case 9:
                        Increment.IncrementNumbers();
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
