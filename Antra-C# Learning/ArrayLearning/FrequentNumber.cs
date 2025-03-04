using System;
using System.Linq;
using System.Collections.Generic;

class FrequentNumber
{
    public static void MostFrequentNumber()
    {
        Console.WriteLine("Enter the sequence of numbers (space-separated):");
        string input = Console.ReadLine();

        // Check if the input is empty
        if (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Input cannot be empty. Please enter valid numbers.");
            return;
        }

        int[] numbers;
        try
        {
            // Try parsing the input into an array of integers
            numbers = input.Split().Select(int.Parse).ToArray();
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid format. Please ensure you enter space-separated integers.");
            return;
        }

        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        int maxCount = 0;

        foreach (int num in numbers)
        {
            if (frequencyMap.ContainsKey(num))
                frequencyMap[num]++;
            else
                frequencyMap[num] = 1;

            if (frequencyMap[num] > maxCount)
                maxCount = frequencyMap[num];
        }

        List<int> mostFrequentNumbers = frequencyMap
            .Where(kv => kv.Value == maxCount)
            .Select(kv => kv.Key)
            .ToList();

        // Find the leftmost of the most frequent numbers
        int leftmost = numbers.First(n => mostFrequentNumbers.Contains(n));

        Console.WriteLine($"The numbers {string.Join(", ", mostFrequentNumbers)} have the same maximal frequency (each occurs {maxCount} times). The leftmost of them is {leftmost}.");
    }
}
