using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    class ReverseWords
    {
        public static void ReverseSentence()
        {
            Console.Write("Enter a sentence: ");
            string input = Console.ReadLine();
            string pattern = "[a-zA-Z0-9#+]+";
            MatchCollection matches = Regex.Matches(input, pattern);
            Stack<string> words = new Stack<string>(matches.Select(m => m.Value));
            string result = Regex.Replace(input, pattern, m => words.Pop());
            Console.WriteLine(result);
        }
    }

}
