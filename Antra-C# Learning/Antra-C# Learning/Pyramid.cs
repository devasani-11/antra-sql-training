using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_C__Learning
{
    public class Pyramid
    {
        public static void PrintPyramid()
        {
            int n = 5;  

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                {
                    Console.Write(" "); 
                }

                for (int k = 1; k <= (2 * i - 1); k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine(); 
            }
        }
    }

}
