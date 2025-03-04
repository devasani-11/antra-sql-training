using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    public class FizBuzz
    {
        public static void CountingGame()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        /* Code Provided:

        int max = 500;
        for (byte i = 0; i < max; i++)
        {
            WriteLine(i);
        }
        The byte type can hold values from 0 to 255. Since we are initializing i as a byte, it will overflow after 255, causing the loop to stop.
        int max = 500;
        for (int i = 0; i < max; i++)  // Change byte to int
        {
            Console.WriteLine(i);
        }
        */

        public static void GuessinGame()
        {
            int correctNumber = new Random().Next(1, 4);

            Console.WriteLine("Guess the number (between 1 and 3): ");

            try
            {
                int guessedNumber = int.Parse(Console.ReadLine());

                if (guessedNumber < 1 || guessedNumber > 3)
                {
                    Console.WriteLine("Please guess a number between 1 and 3.");
                }
                else if (guessedNumber < correctNumber)
                {
                    Console.WriteLine("Too low! Try again.");
                }
                else if (guessedNumber > correctNumber)
                {
                    Console.WriteLine("Too high! Try again.");
                }
                else
                {
                    Console.WriteLine("Correct! You guessed the number!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
