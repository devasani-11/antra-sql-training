using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLearning
{
    class CopyingArray
    {
        public static void CopyArray()
        {
            int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int[] copiedArray = new int[originalArray.Length];

            for (int i = 0; i < originalArray.Length; i++)
            {
                copiedArray[i] = originalArray[i];
            }

            Console.WriteLine("Original Array: " + string.Join(", ", originalArray));
            Console.WriteLine("Copied Array: " + string.Join(", ", copiedArray));
        }
    }
}
