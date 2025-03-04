using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLearning
{
    class ListManager
    {
        public static void ManageListing()
        {
            List<string> items = new List<string>(); 
            while (true) 
            {
                Console.WriteLine("Enter command (+ item, - item, or -- to clear)): ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please enter a valid command.");
                    continue;
                }

                if (input == "--")
                {
                    items.Clear();
                    Console.WriteLine("List cleared.");
                }
                else if (input.StartsWith("+"))
                {
                    string itemToAdd = input.Substring(1).Trim();
                    if (!string.IsNullOrEmpty(itemToAdd))
                    {
                        items.Add(itemToAdd);
                        Console.WriteLine($"Added: {itemToAdd}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter an item to add.");
                    }
                }
                else if (input.StartsWith("-"))
                {
                    string itemToRemove = input.Substring(1).Trim();
                    if (items.Remove(itemToRemove))
                    {
                        Console.WriteLine($"Removed: {itemToRemove}");
                    }
                    else
                    {
                        Console.WriteLine($"Item not found: {itemToRemove}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command. Use + to add, - to remove, or -- to clear.");
                }

                Console.WriteLine("Current List: " + (items.Count > 0 ? string.Join(", ", items) : "Empty"));
            }
        }
    }

}
