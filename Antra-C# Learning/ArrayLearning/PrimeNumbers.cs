using System;
using System.Collections.Generic;

class PrimeNumbers
{
    public static void Prime()
    {
        Console.Write("Enter start number: ");
        int startNum = int.Parse(Console.ReadLine());

        Console.Write("Enter end number: ");
        int endNum = int.Parse(Console.ReadLine());

        int[] primes = FindPrimesInRange(startNum, endNum);

        Console.WriteLine("Prime numbers in range: " + string.Join(", ", primes));
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();

        for (int num = Math.Max(2, startNum); num <= endNum; num++)
        {
            if (IsPrime(num))
            {
                primes.Add(num);
            }
        }

        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }
}
