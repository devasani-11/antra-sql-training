using System;
using ArrayLearning;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select a task to run (1-4) or enter 0 to exit:");
            Console.WriteLine("1. Copying an Array");
            Console.WriteLine("2. Looping Based on a Logical Expression");
            Console.WriteLine("3. Prime Numbers");
            Console.WriteLine("4. Read an array of n integers ");
            Console.WriteLine("5. Longest Sequence of Equal Elements");
            Console.WriteLine("6. Most Frequent Number");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            switch (choice)
            {
                case 1:
                    CopyingArray.CopyArray();
                    break;
                case 2:
                    ListManager.ManageListing();
                    break;
                case 3:
                    PrimeNumbers.Prime();
                    break;
                case 4:
                    RotateAndSum.RotatedArrayToSumArray();
                    break;
                case 5:
                    LongestSequence.LongestEqualSequence();
                    break;
                case 6:
                    FrequentNumber.MostFrequentNumber();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}