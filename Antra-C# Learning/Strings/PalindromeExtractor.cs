using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    class PalindromeExtractor
    {
        public static void ExtractPalindromes()
        {
            Console.Write("Enter a text: ");
            string input = Console.ReadLine();
            string pattern = "[a-zA-Z0-9]+";
            HashSet<string> palindromes = new HashSet<string>();
            foreach (Match match in Regex.Matches(input, pattern))
            {
                string word = match.Value;
                if (word.Length > 1 && word.SequenceEqual(word.Reverse()))
                {
                    palindromes.Add(word);
                }
            }
            Console.WriteLine(string.Join(", ", palindromes.OrderBy(p => p)));
        }
    }
}
