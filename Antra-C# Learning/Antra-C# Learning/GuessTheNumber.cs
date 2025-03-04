using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    class GuessTheNumber
    {
        public static void GuessNumber()
        {
            Random random = new Random();
            int correctNumber = random.Next(1, 4); 

            Console.WriteLine("Guess the number (between 1 and 3):");

            try
            {
                int guessedNumber = int.Parse(Console.ReadLine());

                if (guessedNumber < 1 || guessedNumber > 3)
                {
                    Console.WriteLine("Your guess is out of the valid range. Please guess between 1 and 3.");
                }
                else if (guessedNumber < correctNumber)
                {
                    Console.WriteLine("Your guess is too low.");
                }
                else if (guessedNumber > correctNumber)
                {
                    Console.WriteLine("Your guess is too high.");
                }
                else
                {
                    Console.WriteLine("Correct! You guessed the right number.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }

}
