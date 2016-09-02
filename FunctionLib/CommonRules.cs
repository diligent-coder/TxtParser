using System;
using System.Configuration;
using System.Linq;

namespace FunctionLib
{
    public static class CommonRules
    {
        public static string GetHeader(string header)
        {
            string startCharacter = ConfigurationManager.AppSettings["startCharacter"];
            char[] splitCharacters = ConfigurationManager.AppSettings["splitCharacters"].ToCharArray();
            int startIndex = header.IndexOf(startCharacter, StringComparison.CurrentCultureIgnoreCase);
            header = header.Substring(startIndex);
            return string.Join(",", header.Replace(startCharacter,"")
                .Split(splitCharacters, StringSplitOptions.RemoveEmptyEntries).Select(e=>e.Trim()));
        }
    }
}
