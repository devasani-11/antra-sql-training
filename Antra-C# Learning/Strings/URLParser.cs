using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Strings
{
    class URLParser
    {
        public static void ParseURL()
        {
            Console.Write("Enter a URL: ");
            string url = Console.ReadLine();
            string pattern = @"^(?:(?<protocol>\w+)://)?(?<server>[^/]+)(?:/(?<resource>.*))?$";
            Match match = Regex.Match(url, pattern);
            Console.WriteLine("[protocol] = \"" + match.Groups["protocol"].Value + "\"");
            Console.WriteLine("[server] = \"" + match.Groups["server"].Value + "\"");
            Console.WriteLine("[resource] = \"" + match.Groups["resource"].Value + "\"");
        }
    }

}
