using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_Assignment3
{
    class FibonacciSequence
    {
        public static void Sequence()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(Fibonacci(i) + " ");
            }
        }

        public static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;

            int a = 1, b = 1, result = 0;

            for (int i = 3; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }

            return result;
        }
    }
}
