using System;
using System.Linq;

class RotateAndSum
{
    public static void RotatedArrayToSumArray()
    {
        Console.WriteLine("Enter the array elements (space-separated):");
        string input = Console.ReadLine();

        // Check if the input is not empty and split it into elements
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty. Please enter valid array elements.");
            return;
        }

        int[] array;
        try
        {
            array = input.Split().Select(int.Parse).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please ensure you enter space-separated integers.");
            return;
        }

        Console.WriteLine("Enter number of rotations:");
        string rotationInput = Console.ReadLine();

        // Check if the input is valid for the number of rotations
        if (!int.TryParse(rotationInput, out int k) || k < 0)
        {
            Console.WriteLine("Please enter a valid non-negative integer for the number of rotations.");
            return;
        }

        int n = array.Length;
        int[] sumArray = new int[n];

        for (int r = 1; r <= k; r++)
        {
            int[] rotatedArray = new int[n];

            for (int i = 0; i < n; i++)
            {
                rotatedArray[(i + r) % n] = array[i];
            }

            for (int i = 0; i < n; i++)
            {
                sumArray[i] += rotatedArray[i];
            }

            Console.WriteLine($"Rotated {r}: " + string.Join(" ", rotatedArray));
        }

        Console.WriteLine("Sum Array: " + string.Join(" ", sumArray));
    }
}
