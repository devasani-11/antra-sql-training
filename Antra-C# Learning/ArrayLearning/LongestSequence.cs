using System;
using System.Linq;

class LongestSequence
{
    public static void LongestEqualSequence()
    {
        Console.WriteLine("Enter the array elements (space-separated):");
        string input = Console.ReadLine();

        // Check if the input is empty
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty. Please enter valid array elements.");
            return;
        }

        int[] array;
        try
        {
            // Try parsing the input into an array of integers
            array = input.Split().Select(int.Parse).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please ensure you enter space-separated integers.");
            return;
        }

        int longestStart = 0;
        int longestLength = 1;
        int currentStart = 0;
        int currentLength = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1])
            {
                currentLength++;
            }
            else
            {
                currentStart = i;
                currentLength = 1;
            }

            if (currentLength > longestLength)
            {
                longestLength = currentLength;
                longestStart = currentStart;
            }
        }

        // Get the longest sequence
        int[] longestSequence = array.Skip(longestStart).Take(longestLength).ToArray();
        Console.WriteLine("Longest Sequence: " + string.Join(" ", longestSequence));
    }
}
