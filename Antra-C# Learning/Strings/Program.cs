using Strings;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Select a task to run (1-4) or enter 0 to exit:");
            Console.WriteLine("1. Reverse String");
            Console.WriteLine("2. Reverse Words in a Sentence");
            Console.WriteLine("3. Extract Palindromes");
            Console.WriteLine("4. Parse a URL");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int choice) || choice == 0)
            {
                Console.WriteLine("Exiting program...");
                break;
            }

            switch (choice)
            {
                case 1:
                    ReverseString.Method1();
                    ReverseString.Method2();
                    break;
                case 2:
                    ReverseWords.ReverseSentence();
                    break;
                case 3:
                    PalindromeExtractor.ExtractPalindromes();
                    break;
                case 4:
                    URLParser.ParseURL();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}