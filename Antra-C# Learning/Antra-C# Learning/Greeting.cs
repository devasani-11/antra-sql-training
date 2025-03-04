using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    class Greeting
    {
        public static void GreetOnTime()
        {
            DateTime currentTime = DateTime.Now;

            int hour = currentTime.Hour;

            if (hour >= 6 && hour < 12)
            {
                Console.WriteLine("Good Morning");
            }

            if (hour >= 12 && hour < 18)
            {
                Console.WriteLine("Good Afternoon");
            }

            if (hour >= 18 && hour < 22)
            {
                Console.WriteLine("Good Evening");
            }

            if (hour >= 22 || hour < 6)
            {
                Console.WriteLine("Good Night");
            }
        }
    }

}
