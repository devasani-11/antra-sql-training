using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    class Increment
    {
        public static void IncrementNumbers()
        {
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j <= 24; j += i)
                {
                    Console.Write(j);
                    if (j + i <= 24)
                    {
                        Console.Write(",");
                    }
                }
                Console.WriteLine(); 
            }
        }
    }

}
