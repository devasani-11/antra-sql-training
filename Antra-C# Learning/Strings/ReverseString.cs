using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class ReverseString
    {
        public static void Method1()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(new string(charArray));
        }

        public static void Method2()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            for (int i = input.Length - 1; i >= 0; i--)
            {
                Console.Write(input[i]);
            }
            Console.WriteLine();
        }
    }
 }
