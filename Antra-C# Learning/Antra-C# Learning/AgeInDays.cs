using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    class AgeInDays
    {
        public static void CalculateAge()
        {
            Console.Write("Enter your birth date (yyyy-mm-dd): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            DateTime currentDate = DateTime.Now;
            TimeSpan ageInDays = currentDate - birthDate;

            Console.WriteLine($"You are {ageInDays.Days} days old.");

            int daysToNextAnniversary = 10000 - (ageInDays.Days % 10000);
            DateTime nextAnniversary = currentDate.AddDays(daysToNextAnniversary);

            Console.WriteLine($"Your next 10,000-day anniversary will be on {nextAnniversary.ToShortDateString()}.");
        }
    }

}
