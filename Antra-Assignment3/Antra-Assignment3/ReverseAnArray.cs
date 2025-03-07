using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra_Assignment3
{
    class ReverseAnArray
    {
        public static void ReverseArray(string[] arr)
        {
            int[] numbers = GenerateNumbers(10); 
            Reverse(numbers);
            PrintNumbers(numbers);
        }

        static int[] GenerateNumbers(int length)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = i + 1;
            }
            return arr;
        }

        static void Reverse(int[] array)
        {
            int left = 0, right = array.Length - 1;
            while (left < right)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                left++;
                right--;
            }
        }

        static void PrintNumbers(int[] array)
        {
            foreach (int num in array)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine(); 
        }
    }
}
